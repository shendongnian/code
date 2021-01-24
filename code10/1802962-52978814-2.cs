    using System;
    using System.Collections.Concurrent;
    /// <summary>
    /// Represents a generic cache.
    /// </summary>
    /// <typeparam name="T">Defines the type of the items in the cache.</typeparam>
    public class Cache<T>
    {
        private ConcurrentQueue<T> queue;
        /// <summary>
        /// Is executed when the number of items within the cache run below the
        /// specified warning limit and WarnIfRunningLow is set.
        /// </summary>
        public event EventHandler CacheIsRunningLow;
        /// <summary>
        /// Gets or sets a value indicating whether the CacheIsRunningLow event shall be fired or not.
        /// </summary>
        public bool WarnIfRunningLow
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets a value that represents the lower warning limit.
        /// </summary>
        public int LowerWarningLimit
        {
            get;
            set;
        }
        /// <summary>
        /// Gets the number of items currently stored in the cache.
        /// </summary>
        public int Size
        {
            get;
            private set;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Cache{T}"/> class.
        /// </summary>
        public Cache()
        {
            this.queue = new ConcurrentQueue<T>();
            this.Size = 0;
            this.LowerWarningLimit = 1024;
            this.WarnIfRunningLow = true;
        }
        /// <summary>
        /// Adds an item into the cache.
        /// </summary>
        /// <param name="item">The item to be added to the cache.</param>
        public void Add(T item)
        {
            this.queue.Enqueue(item);
            this.Size++;
        }
        /// <summary>
        /// Adds the items of the specified array to the end of the cache.
        /// </summary>
        /// <param name="items">The items to be added.</param>
        public void AddRange(T[] items)
        {
            this.AddRange(items, 0, items.Length);
        }
        /// <summary>
        /// Adds the specified count of items of the specified array starting
        /// from offset to the end of the cache.
        /// </summary>
        /// <param name="items">The array that contains the items.</param>
        /// <param name="offset">The offset that shall be used.</param>
        /// <param name="count">The number of items that shall be added.</param>
        public void AddRange(T[] items, int offset, int count)
        {
            for (int i = offset; i < count; i++)
                this.Add(items[i]);
        }
        /// <summary>
        /// Reads one item from the cache.
        /// </summary>
        /// <returns>The item that has been read from the cache.</returns>
        /// <exception cref="System.InvalidOperationException">
        /// The cache is empty.
        /// </exception>
        public T Read()
        {
            T item;
            if (!this.queue.TryDequeue(out item))
                throw new InvalidOperationException("The cache is empty.");
            this.Size--;
            if (this.WarnIfRunningLow &&
                this.Size < this.LowerWarningLimit)
            {
                this.CacheIsRunningLow?.Invoke(this, EventArgs.Empty);
            }
            return item;
        }
        /// <summary>
        /// Peeks the next item from cache.
        /// </summary>
        /// <returns>The item that has been read from the cache (without deletion).</returns>
        /// <exception cref="System.InvalidOperationException">
        /// The cache is empty.
        /// </exception>
        public T Peek()
        {
            T item;
            if (!this.queue.TryPeek(out item))
                throw new InvalidOperationException("The cache is empty.");
            return item;
        }
    }
