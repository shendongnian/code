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
                    try {
                        // with the used TryOpenExisting overload you can work with
                        // the mutex object here; you can wait for it or release
                        Console.WriteLine("Application is running!");
                    }
                    finally {
                        mutex.Close();
                    }
                }
                else {
                    Console.WriteLine("Application is NOT running!");
                }
                Console.ReadLine();
            }
        }
    }
