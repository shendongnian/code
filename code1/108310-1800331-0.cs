    class UpdateQueue : IDisposable
    {
         private object m_lockObj;
         private Queue<Action> m_queue;
         private volatile bool m_shutdown;
         private Thread m_thread;
         public UpdateQueue()
         {
             m_lockObj = new Object();
             m_queue = new Queue<Action>();
             m_thread = new Thread(ThreadLoop);
             m_thread.Start();
         }
         public void Add(Action a)
         {
             lock(m_lockObj)
             {
                 m_queue.Enqueue(a);
                 Monitor.Pulse(m_lockObj);
             }
         }
         public void Dispose()
         {
             if (m_thread != null)
             {
                 m_shutdown = true;
                 Monitor.PulseAll(m_lockObj);
                 m_thread.Join();
                 m_thread = null;
             }
         }
         private void ThreadLoop()
         {
             while (! m_shutdown)
             {
                 Action a;
                 lock (m_lockObj)
                 {
                     if (m_queue.Count == 0)
                     {
                         Monitor.Wait(m_lockObj);
                     }
                     if (m_shutdown)
                     {
                         return;
                     }
                     a = m_queuue.Dequeue();
                 }
                 a();
             }
         }
    }
