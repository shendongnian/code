    using System;
    using System.Threading;
        
    class Test
    {
        static void Main()
        {
            // Change to AutoResetEvent to see different behaviour
            EventWaitHandle waitHandle = new ManualResetEvent(false);
            
            for (int i = 0; i < 5; i++)
            {
                int threadNumber = i;
                new Thread(() => WaitFor(threadNumber, waitHandle)).Start();
            }
            // Wait for all the threads to have started
            Thread.Sleep(500);
            
            // Now release the handle three times, waiting a
            // second between each time
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Main thread setting");
                waitHandle.Set();
                Thread.Sleep(1000);
            }
        }
        
        static void WaitFor(int threadNumber, EventWaitHandle waitHandle)
        {
            Console.WriteLine("Thread {0} waiting", threadNumber);
            waitHandle.WaitOne();
            Console.WriteLine("Thread {0} finished", threadNumber);        
        }
    }
