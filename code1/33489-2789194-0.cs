    public class BlockingQueue<T>
    {
        private readonly Subject<T> _queue;
        private readonly IEnumerator<T> _enumerator;
        private readonly object _sync = new object();
        public BlockingQueue()
        {
            _queue = new Subject<T>();
            _enumerator = _queue.GetEnumerator();
        }
        public void Enqueue(T item)
        {
            lock (_sync)
            {
                _queue.OnNext(item);
            }
        }
        public T Dequeue()
        {
            _enumerator.MoveNext();
            return _enumerator.Current;
        }
    }
