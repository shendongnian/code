    using System;
    using System.Collections.Generic;
    using System.Threading;
    
    namespace threadtest
    {
        public delegate void DoneCallbackDelegate(int idArg, bool successArg, string messageArg);
    
        class Program
        {
            static void Main(string[] args)
            {
                Supervisor supv = new Supervisor();
                supv.LoadQueue();
                supv.Dispatch();
            }
        }
    
        public class Supervisor
        {
            public Queue<Worker> pendingWork = new Queue<Worker>();
            public Dictionary<int, Worker> activeWork = new Dictionary<int, Worker>();
    
            private object pendingLock = new object();
            private object activeLock = new object();
    
            private int maxThreads = 200;
    
            public void LoadQueue()
            {
                for (int i = 0; i < 1000; i++)
                {
                    Worker worker = new Worker();
                    worker.Callback = new DoneCallbackDelegate(WorkerFinished);
                    lock (pendingLock)
                    {
                        pendingWork.Enqueue(worker);
                    }
                }
            }
    
            public void Dispatch()
            {
                int activeThreadCount;
    
                while (true)
                {
                    lock (activeLock) { activeThreadCount = activeWork.Count; }
                    while (true)
                    {
                        lock (activeLock)
                        {
                            if (activeWork.Count == maxThreads) break;
                        }
                        lock (pendingWork)
                        {
                            if (pendingWork.Count > 0)
                            {
                                Worker worker = pendingWork.Dequeue();
                                Thread thread = new Thread(new ThreadStart(worker.DoWork));
                                thread.IsBackground = true;
                                worker.ThreadId = thread.ManagedThreadId;
                                lock (activeLock) { activeWork.Add(worker.ThreadId, worker); }
                                thread.Start();
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    Thread.Sleep(200); // wait to see if any workers are done (many ways to do this)
    
                    lock (pendingLock)
                        lock (activeLock)
                        {
                            if ((pendingWork.Count == 0) && (activeWork.Count == 0)) break;
                        }
                }
            }
    
            // remove finished threads from activeWork, resubmit if necessary, and update UI
            public void WorkerFinished(int idArg, bool successArg, string messageArg)
            {
                lock (pendingLock)
                    lock (activeLock)
                    {
                        Worker worker = activeWork[idArg];
                        activeWork.Remove(idArg);
                        if (!successArg)
                        {
                            // check the message or something to see if you should resubmit thread
                            pendingWork.Enqueue(worker);
                        }
                        // update UI
                        int left = Console.CursorLeft;
                        int top = Console.CursorTop;
                        Console.WriteLine(string.Format("pending:{0} active:{1}        ", pendingWork.Count, activeWork.Count));
                        Console.SetCursorPosition(left, top);
                    }
            }
        }
    
        public class Worker
        {
            // this is where you put in your problem-unique stuff
            public int ThreadId { get; set; }
    
            DoneCallbackDelegate callback;
            public DoneCallbackDelegate Callback { set { callback = value; } }
    
            public void DoWork()
            {
                try
                {
                    Thread.Sleep(new Random().Next(500, 5000)); // simulate some effort
                    callback(ThreadId, true, null);
                }
                catch (Exception ex)
                {
                    callback(ThreadId, false, ex.ToString());
                }
            }
        }
    }
