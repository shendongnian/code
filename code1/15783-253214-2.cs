    using System.Threading;
    static class Program {
        static void Main()
        {
            object syncObj = new object();
            lock (syncObj)
            {
                ThreadPool.QueueUserWorkItem(DoWork, syncObj);
    
                System.Console.WriteLine("Main: waiting");
                Monitor.Wait(syncObj);
                System.Console.WriteLine("Main: done");
            }
        }
        static void DoWork(object syncObj)
        {
            
            System.Console.WriteLine("DoWork: working");
            Thread.Sleep(5000); // simulate work
            System.Console.WriteLine("DoWork: done");
            lock (syncObj)
            {
                Monitor.Pulse(syncObj);
            }
        }
    
    }
