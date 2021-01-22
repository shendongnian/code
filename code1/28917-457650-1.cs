    internal class ThreadPool
    {
        private readonly Thread[] m_threads;
        private readonly Queue<Action> m_queue;
        private bool m_shutdown;
        private object m_lockObj;
        public ThreadPool(int numberOfThreads)
        {
            Util.Assume(numberOfThreads > 0, "Invalid thread count!");
            m_queue = new Queue<Action>();
            m_threads = new Thread[numberOfThreads];
            m_lockObj = new object();
            lock (m_lockObj)
            {
                for (int i = 0; i < numberOfWriteThreads; ++i)
                {
                    m_threads[i] = new Thread(ThreadLoop);
                    m_threads[i].Start();
                }
            }
        }
        public void Shutdown()
        {
            lock (m_lockObj)
            {
                m_shutdown = true;
                Monitor.PulseAll(m_lockObj);
                if (OnShuttingDown != null)
                {
                    OnShuttingDown();
                }
            }
            foreach (var thread in m_threads)
            {
                thread.Join();
            }
        }
        public void Enqueue(Action a)
        {
            lock (m_lockObj)
            {
                m_queue.Enqueue(a);
                Monitor.Pulse(m_lockObj);
            }
        }
        private void ThreadLoop()
        {
            Monitor.Enter(m_lockObj);
            while (!m_shutdown)
            {
                if (m_queue.Count == 0)
                {
                    Monitor.Wait(m_lockObj);
                }
                else
                {
                    var a = m_queue.Dequeue();
                    Monitor.Pulse(m_lockObj);
                    Monitor.Exit(m_lockObj);
                    try
                    {
                        a();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An unhandled exception occured!\n:{0}", ex.Message, null);
                    }
                    Monitor.Enter(m_lockObj);
                }
            }
            Monitor.Exit(m_lockObj);
        }
    }
