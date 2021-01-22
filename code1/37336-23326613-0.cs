    public sealed class ConcurrentCircularBuffer<T> : ICollection<T>
    {
        private T[] _items;
        private int _index;
        private bool _full;
    
        public ConcurrentCircularBuffer(int capacity)
        {
            if (capacity <= 1) // need at least two items
                throw new ArgumentException(null, "capacity");
    
            Capacity = capacity;
            _items = new T[capacity];
        }
    
        public int Capacity { get; private set; }
        public long TotalCount { get; private set; }
    
        public int Count
        {
            get
            {
                lock (SyncObject) // full & _index need to be in sync
                {
                    return _full ? Capacity : _index;
                }
            }
        }
    
        public void AddRange(IEnumerable<T> items)
        {
            if (items == null)
                return;
    
            lock (SyncObject)
            {
                foreach (var item in items)
                {
                    AddWithLock(item);
                }
            }
        }
    
        private void AddWithLock(T item)
        {
            _items[_index] = item;
            _index++;
            if (_index == Capacity)
            {
                _full = true;
                _index = 0;
            }
            TotalCount++;
        }
    
        public void Add(T item)
        {
            lock (SyncObject)
            {
                AddWithLock(item);
            }
        }
    
        public void Clear()
        {
            lock (SyncObject)
            {
                _items = new T[Capacity];
                _index = 0;
                _full = false;
                TotalCount = 0;
            }
        }
    
        // this gives raw access to the underlying buffer. not sure I should keep that
        public T this[int index]
        {
            get
            {
                return _items[index];
            }
        }
    
        public T[] GetTail(long startIndex)
        {
            long lostCount;
            return GetTail(startIndex, out lostCount);
        }
    
        public T[] GetTail(long startIndex, out long lostCount)
        {
            if (startIndex < 0 || startIndex >= TotalCount)
                throw new ArgumentOutOfRangeException("startIndex");
    
            T[] array = ToArray();
            lostCount = (TotalCount - Count) - startIndex;
            if (lostCount >= 0)
                return array;
    
            lostCount = 0;
    
            // this maybe could optimized to not allocate the initial array
            // but in multi-threading environment, I suppose this is arguable (and more difficult).
            T[] chunk = new T[TotalCount - startIndex];
            Array.Copy(array, array.Length - (TotalCount - startIndex), chunk, 0, chunk.Length);
            return chunk;
        }
    
        public T[] ToArray()
        {
            lock (SyncObject)
            {
                T[] items = new T[_full ? Capacity : _index];
                if (_full)
                {
                    if (_index == 0)
                    {
                        Array.Copy(_items, items, Capacity);
                    }
                    else
                    {
                        Array.Copy(_items, _index, items, 0, Capacity - _index);
                        Array.Copy(_items, 0, items, Capacity - _index, _index);
                    }
                }
                else if (_index > 0)
                {
                    Array.Copy(_items, items, _index);
                }
                return items;
            }
        }
    
        public IEnumerator<T> GetEnumerator()
        {
            return ToArray().AsEnumerable().GetEnumerator();
        }
    
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    
        bool ICollection<T>.Contains(T item)
        {
            return _items.Contains(item);
        }
    
        void ICollection<T>.CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException("array");
    
            if (array.Rank != 1)
                throw new ArgumentException(null, "array");
    
            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException("arrayIndex");
    
            if ((array.Length - arrayIndex) < Count)
                throw new ArgumentException(null, "array");
    
            T[] thisArray = ToArray();
            Array.Copy(thisArray, 0, array, arrayIndex, thisArray.Length);
        }
    
        bool ICollection<T>.IsReadOnly
        {
            get
            {
                return false;
            }
        }
    
        bool ICollection<T>.Remove(T item)
        {
            return false;
        }
    
        private static object _syncObject;
        private static object SyncObject
        {
            get
            {
                if (_syncObject == null)
                {
                    object obj = new object();
                    Interlocked.CompareExchange(ref _syncObject, obj, null);
                }
                return _syncObject;
            }
        }
    }
