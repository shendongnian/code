    class MyListWrapper<T, TValue> : IList<T>
    {
        private Dictionary<T, TValue>.KeyCollection keys;
        public MyListWrapper(Dictionary<T, TValue>.KeyCollection keys)
        {
            this.keys = keys;
        }
        #region IList<T> Members
        public int IndexOf(T item)
        {
            if (item == null)
                throw new ArgumentNullException();
            IEnumerator<T> e = keys.GetEnumerator();
            int i = 0;
            while (e.MoveNext())
            {
                if (e.Current.Equals(item))
                    return i;
                i++;
            }
            throw new Exception("Item not found!");
        }
        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }
        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }
        public T this[int index]
        {
            get
            {
                IEnumerator<T> e = keys.GetEnumerator();
                if (index < 0 || index > keys.Count)
                    throw new IndexOutOfRangeException();
                int i = 0;
                while (e.MoveNext() && i != index)
                {
                    i++;
                }
                return e.Current;
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        #endregion
        #region ICollection<T> Members
        public void Add(T item)
        {
            throw new NotImplementedException();
        }
        public void Clear()
        {
            throw new NotImplementedException();
        }
        public bool Contains(T item)
        {
            return keys.Contains(item);
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            keys.CopyTo(array, arrayIndex);
        }
        public int Count
        {
            get { return keys.Count; }
        }
        public bool IsReadOnly
        {
            get { return true; }
        }
        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region IEnumerable<T> Members
        public IEnumerator<T> GetEnumerator()
        {
            return keys.GetEnumerator();
        }
        #endregion
        #region IEnumerable Members
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return keys.GetEnumerator();
        }
        #endregion
    }
