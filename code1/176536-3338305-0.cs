    using System;
    using System.Collections.Generic;
    using System.Threading;
    
    namespace ThreadTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                Supervisor supervisor = new Supervisor();
                supervisor.LaunchThreads();
                Console.ReadLine();
                supervisor.KillActiveThreads();
                Console.ReadLine();
            }
    
            public delegate void WorkerCallbackDelegate(int threadIdArg);
            public static object locker = new object();
    
            class Supervisor
            {
                Queue<Thread> pendingThreads = new Queue<Thread>();
                Dictionary<int, Worker> activeWorkers = new Dictionary<int, Worker>();
    
                public void LaunchThreads()
                {
                    for (int i = 0; i < 20; i++)
                    {
                        Worker worker = new Worker();
                        worker.DoneCallBack = new WorkerCallbackDelegate(WorkerCallback);
                        Thread thread = new Thread(worker.DoWork);
                        thread.IsBackground = true;
                        thread.Start();
                        lock (locker)
                        {
                            activeWorkers.Add(thread.ManagedThreadId, worker);
                        }
                    }
                }
    
                public void KillActiveThreads()
                {
                    lock (locker)
                    {
                        foreach (Worker worker in activeWorkers.Values)
                        {
                            worker.StopWork();
                        }
                    }
                }
    
                public void WorkerCallback(int threadIdArg)
                {
                    lock (locker)
                    {
                        activeWorkers.Remove(threadIdArg);
                        if (activeWorkers.Count == 0)
                        {
                            Console.WriteLine("no more active threads");
                        }
                    }
                }
            }
    
            class Worker
            {
                public WorkerCallbackDelegate DoneCallBack { get; set; }
                volatile bool quitEarly;
    
                public void DoWork()
                {
                    quitEarly = false;
                    Console.WriteLine(Thread.CurrentThread.ManagedThreadId.ToString() + " started");
                    DateTime startTime = DateTime.Now;
                    while (!quitEarly && ((DateTime.Now - startTime).TotalSeconds < new Random().Next(1, 10)))
                    {
                        Thread.Sleep(1000);
                    }
                    Console.WriteLine(Thread.CurrentThread.ManagedThreadId.ToString() + " stopped");
                    DoneCallBack(Thread.CurrentThread.ManagedThreadId);
                }
    
                public void StopWork()
                {
                    quitEarly = true;
                }
            }
        }
    }
