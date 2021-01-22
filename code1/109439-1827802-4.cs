    namespace ThreadTracker
    {
        using System.Collections.Generic;
        using System.Collections.ObjectModel;
        using System.Threading;
    
        public class TrackedThread
        {
            private static readonly IList<Thread> threadList = new List<Thread>();
    
            private readonly Thread thread;
    
            private readonly ParameterizedThreadStart start1;
    
            private readonly ThreadStart start2;
    
            public TrackedThread(ParameterizedThreadStart start)
            {
                this.start1 = start;
                this.thread = new Thread(this.StartThreadParameterized);
                lock (threadList)
                {
                    threadList.Add(this.thread);
                }
            }
    
            public TrackedThread(ThreadStart start)
            {
                this.start2 = start;
                this.thread = new Thread(this.StartThread);
                lock (threadList)
                {
                    threadList.Add(this.thread);
                }
            }
    
            public TrackedThread(ParameterizedThreadStart start, int maxStackSize)
            {
                this.start1 = start;
                this.thread = new Thread(this.StartThreadParameterized, maxStackSize);
                lock (threadList)
                {
                    threadList.Add(this.thread);
                }
            }
    
            public TrackedThread(ThreadStart start, int maxStackSize)
            {
                this.start2 = start;
                this.thread = new Thread(this.StartThread, maxStackSize);
                lock (threadList)
                {
                    threadList.Add(this.thread);
                }
            }
    
            public static int Count
            {
                get
                {
                    lock (threadList)
                    {
                        return threadList.Count;
                    }
                }
            }
    
            public static IEnumerable<Thread> ThreadList
            {
                get
                {
                    lock (threadList)
                    {
                        return new ReadOnlyCollection<Thread>(threadList);
                    }
                }
            }
    
            // either: (a) expose the thread object itself via a property or,
            // (b) expose the other Thread public methods you need to replicate.
            // This example uses (a).
            public Thread Thread
            {
                get
                {
                    return this.thread;
                }
            }
    
            private void StartThreadParameterized(object obj)
            {
                try
                {
                    this.start1(obj);
                }
                finally
                {
                    lock (threadList)
                    {
                        threadList.Remove(this.thread);
                    }
                }
            }
    
            private void StartThread()
            {
                try
                {
                    this.start2();
                }
                finally
                {
                    lock (threadList)
                    {
                        threadList.Remove(this.thread);
                    }
                }
            }
        }
    }
