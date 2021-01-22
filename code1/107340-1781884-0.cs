    public class BlockingQueue<T>
    {
        Queue<T> _queue = new Queue<T>();
        Semaphore _sem = new Semaphore(0, Int32.MaxValue);
        public void Enqueue(T item)
        {
            lock (_queue)
            {
                _queue.Enqueue(item);
            }
            _sem.Release();
        }
        public T Dequeue()
        {
            _sem.WaitOne();
            lock (_queue)
            {
                return _queue.Dequeue();
            }
        }
    }
