    using System;
    using System.Threading;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Mutex mutex;
                if (Mutex.TryOpenExisting("My unique mutex name", out mutex)) {
                    Console.WriteLine("Application is running!");
                }
                else {
                    Console.WriteLine("Application is NOT running!");
                }
                Console.ReadLine();
            }
        }
    }
