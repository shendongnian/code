    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    
    namespace HeronEngine
    {
        public delegate void Task();
    
        public static class Parallelizer 
        {
            static List<Task> allTasks = new List<Task>();
            static List<Thread> threads = new List<Thread>();      
            static ManualResetEvent signal = new ManualResetEvent(false);
            static bool shuttingDown = false;
            public static void Initialize(int maxThreads)
            {
                for (int i = 0; i < maxThreads; ++i)
                {
                    Thread t = new Thread(ThreadPump);
                    t.Priority = ThreadPriority.Highest;
                    threads.Add(t);
                    t.Start();
                }
            }
    
            public static void ReleaseThreads()
            {
                signal.Set();
            }
    
            public static void BlockThreads()
            {
                if (!shuttingDown)
                    signal.Reset();
            }
    
            public static Task GetTask()
            {
                lock (allTasks)
                {
                    if (allTasks.Count == 0)
                    {
                        BlockThreads();
                        return null;
                    }
                    Task t = allTasks.Peek();
                    allTasks.Pop();
                    return t;
                }
            }
    
            public static void ThreadPump()
            {
                while (!shuttingDown)
                {
                    signal.WaitOne();
                    Task task = GetTask();
                    while (task != null)
                    {
                        task();
                        task = GetTask();
                    }
                }
            }
    
            /// <summary>
            /// Distributes work across a number of threads equivalent to the number 
            /// of worker threads. I create a single worker thread per core, and set
            /// its priority to high.
            /// </summary>
            /// <param name="localTasks"></param>
            public static void DistributeWork(List<Task> localTasks)
            {
                // Create a list of handles indicating what the main thread should wait for
                WaitHandle[] handles = new WaitHandle[localTasks.Count];
    
                lock (allTasks)
                {
                    // Iterate over the list of localTasks, creating a new task that 
                    // will signal when it is done.
                    for (int i = 0; i < localTasks.Count; ++i)
                    {
                        Task t = localTasks[i];
                        ManualResetEvent e = new ManualResetEvent(false);
                        Task signalingTask = () => { t(); e.Set(); };
                        allTasks.Add(signalingTask);
                        handles[i] = e;
                    }
                }
    
                // Signal to waiting threads that there is work
                ReleaseThreads();
    
                // Wait until all of the designated work items are completed.
                Semaphore.WaitAll(handles);
            }
    
            public static void CleanUp()
            {
                shuttingDown = true;
                ReleaseThreads();
            }
        }    
    }
 
