    using System.Threading;
    static class Program {
        static void Main()
        {
            ThreadPool.QueueUserWorkItem(DoWork);
    
            System.Console.WriteLine("Main: waiting");
            wait.WaitOne();
            System.Console.WriteLine("Main: done");
        }
        static void DoWork(object state)
        {
            System.Console.WriteLine("DoWork: working");
            Thread.Sleep(5000); // simulate work
            System.Console.WriteLine("DoWork: done");
            wait.Set();
        }
        static readonly ManualResetEvent wait = new ManualResetEvent(false);
    
    }
