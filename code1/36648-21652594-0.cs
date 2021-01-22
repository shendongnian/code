    public class SlidingWindowCollection<T> : ICollection<T>
    {
        private int _windowSize;
        private Queue<T> _source;
        public SlidingWindowCollection(int windowSize)
        {
            _windowSize = windowSize;
            _source = new Queue<T>(windowSize);
        }
        public void Add(T item)
        {
            if (_source.Count == _windowSize)
            {
                _source.Dequeue();
            }
            _source.Enqueue(item);
        }
        public void Clear()
        {
            _source.Clear();
        }
        ...and just keep forwarding all other ICollection<T> methods to _source.
    }
