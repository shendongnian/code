    public class CancellableBlockingCollection<T>
    {
        private Queue<T> m_Queue = new Queue<T>();
    
        public T Take(WaitHandle cancel)
        {
            lock (m_Queue)
            {
                while (m_Queue.Count <= 0)
                {
                    if (!Monitor.Wait(m_Queue, 1000))
                    {
                        if (cancel.WaitOne(0))
                        {
                            throw new InvalidOperationException();
                        }
                    }
                }
                return m_Queue.Dequeue();
            }
        }
    
        public void Add(T data)
        {
            lock (m_Queue)
            {
                m_Queue.Enqueue(data);
                Monitor.Pulse(m_Queue);
            }
        }
    }
