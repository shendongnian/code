    using System;
    using System.Threading;
    public class Example
    {
        public static void Main()
        {
            ThreadPool.SetMaxThreads(100);
            // Queue the task.
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadProc));
            Console.WriteLine("Main thread does some work, then sleeps.");
            Thread.Sleep(1000);
    
            Console.WriteLine("Main thread exits.");
        }
    
        // This thread procedure performs the task.
        static void ThreadProc(Object stateInfo)
        {
            Console.WriteLine("Hello from the thread pool.");
        }
    }
