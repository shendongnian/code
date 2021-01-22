    using System;
    using System.Threading;
    namespace ThreadLock
    {
        class Program
        {
            static void Main(string[] args)
            {
                lock ("my lock")
                {
                    ManualResetEvent evt = new ManualResetEvent(false);
                    WorkerObject worker = new WorkerObject(evt);
                    Thread t = new Thread(new ThreadStart(worker.Work));
                    t.Start();
                    evt.WaitOne();
                }
            }
        }
        class WorkerObject
        {
            private ManualResetEvent _evt;
            public WorkerObject(ManualResetEvent evt)
            {
                _evt = evt;
            }
            public void Work()
            {
                lock ("my lock")
                {
                    Console.WriteLine("worked.");
                    _evt.Set();
                }
            }
        }
    }
