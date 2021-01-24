    using System;
    using System.Threading;
    using System.Threading.Tasks;
    namespace Demo
    {
        static class Program
        {
            static void Main()
            {
                Thread thread = new Thread(work);
                thread.Start();
                Task.Run(() =>
                {
                    thread.Join();
                    Console.WriteLine("Run after thread finished");
                });
                Console.ReadLine();
            }
            static void work()
            {
                Console.WriteLine("Starting work");
                Thread.Sleep(1000);
                Console.WriteLine("Finished work");
            }
        }
    }
