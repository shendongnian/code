    public class Channel<T>
    {
        private readonly Queue<T> _queue = new Queue<T>();
        public void Enqueue(T item)
        {
            lock (_queue)
            {
                _queue.Enqueue(item);
                if (_queue.Count == 1)
                    Monitor.PulseAll(_queue);
            }
        }
    
        public T Dequeue()
        {
            lock (_queue)
            {
                while (_queue.Count == 0)
                    Monitor.Wait(_queue);
    
                return _queue.Dequeue();
            }
        }
    }
