    public class NotifyingBlockingCollection<T>
    {
        private BlockingCollection<T> m_Items = new BlockingCollection<T>();
        private Queue<Action<T>> m_Callbacks = new Queue<Action<T>>();
    
        public NotifyingBlockingCollection()
        {
        }
    
        public void Add(T item)
        {
            lock (m_Callbacks)
            {
                if (m_Callbacks.Count > 0)
                {
                    Action<T> callback = m_Callbacks.Dequeue();
                    callback.BeginInvoke(item, null, null); // Transfer to the thread pool.
                }
                else
                {
                    m_Items.Add(item);
                }
            }
        }
    
        public T Take()
        {
            return m_Items.Take();
        }
    
        public void RegisterForTake(Action<T> callback)
        {
            lock (m_Callbacks)
            {
                T item;
                if (m_Items.TryTake(out item))
                {
                    callback.BeginInvoke(item, null, null); // Transfer to the thread pool.
                }
                else
                {
                    m_Callbacks.Enqueue(callback);
                }
            }
        }
    }
