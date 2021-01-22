    namespace ThreadTracker
    {
        using System.Collections.Generic;
        using System.Collections.ObjectModel;
        using System.Threading;
    
        public class TrackedThread
        {
            private static readonly object m_locker = new object();
            private static readonly List<Thread> m_threadList = new List<Thread>();
            private readonly Thread m_thread;
            private readonly ParameterizedThreadStart m_start1;
            private readonly ThreadStart m_start2;
    
            public TrackedThread(ParameterizedThreadStart start)
            {
                this.m_start1 = start;
                this.m_thread = new Thread(this.StartThreadParameterized);
                lock (m_locker)
                {
                    m_threadList.Add(this.m_thread);
                }
            }
    
            public TrackedThread(ThreadStart start)
            {
                this.m_start2 = start;
                this.m_thread = new Thread(this.StartThread);
                lock (m_locker)
                {
                    m_threadList.Add(this.m_thread);
                }
            }
    
            public TrackedThread(ParameterizedThreadStart start, int maxStackSize)
            {
                this.m_start1 = start;
                this.m_thread = new Thread(this.StartThreadParameterized, maxStackSize);
                lock (m_locker)
                {
                    m_threadList.Add(this.m_thread);
                }
            }
    
            public TrackedThread(ThreadStart start, int maxStackSize)
            {
                this.m_start2 = start;
                this.m_thread = new Thread(this.StartThread, maxStackSize);
                lock (m_locker)
                {
                    m_threadList.Add(this.m_thread);
                }
            }
    
            public static int Count
            {
                get
                {
                    lock (m_locker)
                    {
                        return m_threadList.Count;
                    }
                }
            }
    
            public static IEnumerable<Thread> ThreadList
            {
                get
                {
                    lock(m_locker)
                    {
                        return new ReadOnlyCollection<Thread>(m_threadList);
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
                    return this.m_thread;
                }
            }
    
            private void StartThreadParameterized(object obj)
            {
                try
                {
                    this.m_start1(obj);
                }
                finally
                {
                    lock(m_locker)
                    {
                        m_threadList.Remove(this.m_thread);
                    }
                }
            }
    
            private void StartThread()
            {
                try
                {
                    this.m_start2();
                }
                finally
                {
                    lock (m_locker)
                    {
                        m_threadList.Remove(this.m_thread);
                    }
                }
            }
        }
    }
