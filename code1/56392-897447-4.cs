    public class PagedList<T> : IPagedList<T>
    {
        private List<T> _collection = new List<T>();
        public IList<T> GetPagedList(int pageNo, int pageSize)
        {
            return _collection.Take(pageSize).Skip((pageNo - 1) * pageSize).ToList();
        }
        public int IndexOf(T item)
        {
            return _collection.IndexOf(item);
        }
        public void Insert(int index, T item)
        {
            _collection.Insert(index, item);
        }
        public void RemoveAt(int index)
        {
            _collection.RemoveAt(index);
        }
        public T this[int index]
        {
            get
            {
                return _collection[index];
            }
            set
            {
                _collection[index] = value;
            }
        }
        public void Add(T item)
        {
            _collection.Add(item);
        }
        public void Clear()
        {
            _collection.Clear();
        }
        public bool Contains(T item)
        {
            return _collection.Contains(item);
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            _collection.CopyTo(array, arrayIndex);
        }
        int Count
        {
            get
            {
                return _collection.Count;
            }
        }
        public bool IsReadOnly
        {
            get { return false; }
        }
        public bool Remove(T item)
        {
            return _collection.Remove(item);
        }
        public IEnumerator<T> GetEnumerator()
        {
            return _collection.GetEnumerator();
        }
        int ICollection<T>.Count
        {
            get { return _collection.Count; }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _collection.GetEnumerator();
        }
        public void CopyTo(Array array, int index)
        {
            T[] arr = new T[array.Length];
            for (int i = 0; i < array.Length ; i++)
            {
                arr[i] = (T)array.GetValue(i);
            }
            _collection.CopyTo(arr, index);
        }
        int ICollection.Count
        {
            get { return _collection.Count; }
        }
        // The IsSynchronized Boolean property returns True if the 
        // collection is designed to be thread safe; otherwise, it returns False.
        public bool IsSynchronized
        {
            get 
            {
                return false;
            }
        }
        public object SyncRoot
        {
            get 
            {
                return this;
            }
        }
    }
