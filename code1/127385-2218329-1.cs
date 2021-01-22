    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    
    namespace HeronEngine
    {
        /// <summary>
        /// Represents a work item.
        /// </summary>
        public delegate void Task();
    
        /// <summary>
        /// This class is intended to efficiently distribute work 
        /// across the number of cores. 
        /// </summary>
        public static class Parallelizer 
        {
            /// <summary>
            /// List of tasks that haven't been yet acquired by a thread 
            /// </summary>
            static List<Task> allTasks = new List<Task>();
            
            /// <summary>
            /// List of threads. Should be one per core. 
            /// </summary>
            static List<Thread> threads = new List<Thread>();
          
            /// <summary>
            /// When set signals that there is more work to be done
            /// </summary>
            static ManualResetEvent signal = new ManualResetEvent(false);
    
            /// <summary>
            /// Used to tell threads to stop working.
            /// </summary>
            static bool shuttingDown = false;
    
            /// <summary>
            /// Creates a number of high-priority threads for performing 
            /// work. The hope is that the OS will assign each thread to 
            /// a separate core.
            /// </summary>
            /// <param name="cores"></param>
            public static void Initialize(int cores)
            {
                for (int i = 0; i < cores; ++i)
                {
                    Thread t = new Thread(ThreadMain);
                    // This system is not designed to play well with others
                    t.Priority = ThreadPriority.Highest;
                    threads.Add(t);
                    t.Start();
                }
            }
    
            /// <summary>
            /// Indicates to all threads that there is work
            /// to be done.
            /// </summary>
            public static void ReleaseThreads()
            {
                signal.Set();
            }
    
            /// <summary>
            /// Used to indicate that there is no more work 
            /// to be done, by unsetting the signal. Note: 
            /// will not work if shutting down.
            /// </summary>
            public static void BlockThreads()
            {
                if (!shuttingDown)
                    signal.Reset();
            }
    
            /// <summary>
            /// Returns any tasks queued up to perform, 
            /// or NULL if there is no work. It will reset
            /// the global signal effectively blocking all threads
            /// if there is no more work to be done.
            /// </summary>
            /// <returns></returns>
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
    
            /// <summary>
            /// Primary function for each thread
            /// </summary>
            public static void ThreadMain()
            {
                while (!shuttingDown)
                {
                    // Wait until work is available
                    signal.WaitOne();
    
                    // Get an available task
                    Task task = GetTask();
    
                    // Note a task might still be null becaue
                    // another thread might have gotten to it first
                    while (task != null)
                    {
                        // Do the work
                        task();
    
                        // Get the next task
                        task = GetTask();
                    }
                }
            }
    
            /// <summary>
            /// Distributes work across a number of threads equivalent to the number 
            /// of cores. All tasks will be run on the available cores. 
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
    
                        // Create an event used to signal that the task is complete
                        ManualResetEvent e = new ManualResetEvent(false);
    
                        // Create a new signaling task and add it to the list
                        Task signalingTask = () => { t(); e.Set(); };
                        allTasks.Add(signalingTask);
    
                        // Set the corresponding wait handler 
                        handles[i] = e;
                    }
                }
    
                // Signal to waiting threads that there is work
                ReleaseThreads();
    
                // Wait until all of the designated work items are completed.
                Semaphore.WaitAll(handles);
            }
    
            /// <summary>
            /// Indicate to the system that the threads should terminate
            /// and unblock them.
            /// </summary>
            public static void CleanUp()
            {
                shuttingDown = true;
                ReleaseThreads();
            }
        }    
    }
