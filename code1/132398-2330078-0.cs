    using System;
    using System.Threading;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Mutex mutex = new Mutex(false, "AwesomeMutex");
    
                Console.WriteLine("ConsoleApplication1 created mutex, waiting . . .");
    
                mutex.WaitOne();
    
                Console.Write("Waiting for input. . .");
                Console.ReadKey(true);
    
                mutex.ReleaseMutex();
                Console.WriteLine("Disposed mutex");
            }
        }
    }
