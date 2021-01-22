    public class CallbackCollection<T>
    {
        // Sychronization object to prevent race conditions.
        private object _SyncObject = new object();
        // A queue for callbacks that are waiting for items.
        private ConcurrentQueue<Action<T>> _Callbacks = new ConcurrentQueue<Action<T>>();
        // A queue for items that are waiting for callbacks.
        private ConcurrentQueue<T> _Items = new ConcurrentQueue<T>();
        public void Add(T item)
        {
            Action<T> callback;
            lock (_SyncObject)
            {
                // Try to get a callback. If no callback is available,
                // then enqueue the item to wait for the next callback
                // and return.
                if (!_Callbacks.TryDequeue(out callback))
                {
                    _Items.Enqueue(item);
                    return;
                }
            }
            
            ExecuteCallback(callback, item);
        }
        public void TakeAndCallback(Action<T> callback)
        {
            T item;
            lock(_SyncObject)
            {
                // Try to get an item. If no item is available, then
                // enqueue the callback to wait for the next item
                // and return.
                if (!_Items.TryDequeue(out item))
                {
                    _Callbacks.Enqueue(callback);
                    return;
                }
            }
            ExecuteCallback(callback, item);
        }
        private void ExecuteCallback(Action<T> callback, T item)
        {
            // Use a new Task to execute the callback so that we don't
            // execute it on the current thread.
            Task.Factory.StartNew(() => callback.Invoke(item));
        }
    }
