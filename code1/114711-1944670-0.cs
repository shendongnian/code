    /// <summary>
    /// Thread safe queue of client ids
    /// </summary>
    internal class SlotQueue
    {
        private readonly AutoResetEvent _event = new AutoResetEvent(false);
        private readonly Queue<int> _items = new Queue<int>();
        private int _waitCount;
        /// <summary>
        /// Initializes a new instance of the <see cref="SlotQueue"/> class.
        /// </summary>
        /// <param name="itemCount">The item count.</param>
        public SlotQueue(int itemCount)
        {
            // Create queue items
            for (int i = 0; i < itemCount; ++i)
                _items.Enqueue(i);
        }
        /// <summary>
        /// Gets number of clients waiting in the queue.
        /// </summary>
        public int QueueSize
        {
            get { return _waitCount; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="waitTime">Number of milliseconds to wait for an id</param>
        /// <returns></returns>
        public int Deqeue(int waitTime)
        {
            // Thread safe check if we got any free items
            lock (_items)
            {
                if (_items.Count > 0)
                    return _items.Dequeue();
            }
            // Number of waiting clients.
            Interlocked.Increment(ref _waitCount);
            // wait for an item to get enqueued
            // false = timeout
            bool res = _event.WaitOne(waitTime);
            if (!res)
            {
                Interlocked.Decrement(ref _waitCount);
                return -1;
            }
            // try to fetch queued item
            lock (_items)
            {
                if (_items.Count > 0)
                {
                    Interlocked.Decrement(ref _waitCount);
                    return _items.Dequeue();
                }
            }
            // another thread got the last item between waitOne and the lock.
            Interlocked.Decrement(ref _waitCount);
            return -1;
        }
        /// <summary>
        /// Enqueue a client ID
        /// </summary>
        /// <param name="id">Id to enqueue</param>
        public void Enqueue(int id)
        {
            lock (_items)
            {
                _items.Enqueue(id);
                if (_waitCount > 0)
                    _event.Set();
            }
        }
    }
