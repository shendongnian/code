    using System;
    using System.Threading;
    
    namespace MutexExample
    {
        class Program
        {
            static Mutex m = new Mutex(false, "myMutex");//create a new NAMED mutex, DO NOT OWN IT
            static void Main(string[] args)
            {
                Console.WriteLine("Waiting to acquire Mutex");
                m.WaitOne(); //ask to own the mutex, you'll be queued until it is released
                Console.WriteLine("Mutex acquired.\nPress enter to release Mutex");
                Console.ReadLine();
                m.ReleaseMutex();//release the mutex so other processes can use it
            }
        }
    }
