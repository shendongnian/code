    using System;
    using System.Threading;
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                Mutex mutex = new Mutex(false, "AwesomeMutex");
                Console.WriteLine("ConsoleApplication2 Created mutex");
    
                mutex.WaitOne();
    
                Console.WriteLine("ConsoleApplication2 got signalled");
    
                mutex.ReleaseMutex();
            }
        }
    }
