    public class BoundedQueue<T>
    {
        private Queue<T> _queue;
        private int _maxSize;
    
        public BoundedQueue(int maxSize)
        {
            if (maxSize <= 0)
                throw new ArgumentOutOfRangeException("maxSize");
    
            _queue = new Queue<T>(maxSize);
            _maxSize = maxSize;
        }
    
        public int Count
        {
            get { return _queue.Count; }
        }
    
        /// <summary>
        /// Adds a new item to the queue and, if the queue is at its
        /// maximum capacity, also removes the oldest item
        /// </summary>
        /// <returns>
        /// True if an item was dequeued during this operation;
        /// otherwise, false
        /// </returns>
        public bool EnqueueDequeue(T value, out T dequeued)
        {
            dequeued = default(T);
            bool dequeueOccurred = false;
    
            if (_queue.Count == _maxSize)
            {
                dequeued = _queue.Dequeue();
                dequeueOccurred = true;
            }
    
            _queue.Enqueue(value);
    
            return dequeueOccurred;
        }
    }
