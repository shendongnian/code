    public class NotifyingBlockingCollection<T> : BlockingCollection<T>
    {
        private Thread m_Notifier;
        private BlockingCollection<Action<T>> m_Callbacks = new BlockingCollection<Action<T>>();
    
        public NotifyingBlockingCollection()
        {
            m_Notifier = new Thread(Notify);
            m_Notifier.IsBackground = true;
            m_Notifier.Start();
        }
    
        private void Notify()
        {
            while (true)
            {
                Action<T> callback = m_Callbacks.Take();
                T item = Take();
                callback.BeginInvoke(item, null, null); // Transfer to the thread pool.
            }
        }
    
        public void RegisterForTake(Action<T> callback)
        {
            m_Callbacks.Add(callback);
        }
    }
