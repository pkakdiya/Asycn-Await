using System;
using System.IO;
using System.Threading.Tasks;

namespace Aysnc_Await
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<int> result = HandleFileAsync();
            Console.WriteLine("Please wait the HandleFileFunction is running aync");
            /** If we want to wait until the task is completed then wait */
            /** The following statement will wait */
            //result.Wait(); 
            var x = result.ContinueWith(tsk => {
                Console.WriteLine($"The File Reading Operation is completed here is the file content length: {tsk.Result}");
            }); //result.Result; //result will wait for it
            
        }

        static async Task<int> HandleFileAsync() 
        {
            string file = @"C:\Users\pkakadiy\Desktop\DotNetCore_Link.txt";
            Console.WriteLine("HandleFile Enter");
            int count = 0;
            using(StreamReader sr = new StreamReader(file)) 
            {
                string v = await sr.ReadToEndAsync();
                count += v.Length;

                // ... A slow-running computation.
                //     Dummy code.
                for (int i = 0; i < 10000; i++)
                {
                    int x = v.GetHashCode();
                    if (x == 0)
                    {
                        count--;
                    }
                }
            }
            Console.WriteLine("HandleFile exit");
            return count;
        }
    }
}
