    public class MyList<T> : IList<T>
    {
        private List<T> _list = new List<T>();
        public event EventHandler BeforeAdd;
        public event EventHandler AfterAdd;
        public void Add(T item)
        {
            // Here we can do what ever we want, buffering multiple events etc..
            BeforeAdd?.Invoke(this, null);
            _list.Add(item);
            AfterAdd?.Invoke(this, null);
        }
        #region Forwarding to List<T>
        public T this[int index] { get => _list[index]; set => _list[index] = value; }
        public int Count => _list.Count;
        public bool IsReadOnly => false;
        public void Clear() => _list.Clear();
        public bool Contains(T item) => _list.Contains(item);
        public void CopyTo(T[] array, int arrayIndex) => _list.CopyTo(array, arrayIndex);
        public IEnumerator<T> GetEnumerator() => _list.GetEnumerator();
        public int IndexOf(T item) => _list.IndexOf(item);
        public void Insert(int index, T item) => _list.Insert(index, item);
        public bool Remove(T item) => _list.Remove(item);
        public void RemoveAt(int index) => _list.RemoveAt(index);
        IEnumerator IEnumerable.GetEnumerator() => _list.GetEnumerator();
        #endregion
    }
