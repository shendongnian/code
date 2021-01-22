    /// <summary>
    /// Collection of child items. This collection automatically set the
    /// Parent property of the child items when they are added or removed
    /// </summary>
    /// <typeparam name="P">Type of the parent object</typeparam>
    /// <typeparam name="T">Type of the child items</typeparam>
    public class ChildItemCollection<P, T> : IList<T>
        where P : class
        where T : IChildItem<P>
    {
        private P _parent;
        private IList<T> _collection;
        public ChildItemCollection(P parent)
        {
            this._parent = parent;
            this._collection = new List<T>();
        }
        public ChildItemCollection(P parent, IList<T> collection)
        {
            this._parent = parent;
            this._collection = collection;
        }
        #region IList<T> Members
        public int IndexOf(T item)
        {
            return _collection.IndexOf(item);
        }
        public void Insert(int index, T item)
        {
            if (item != null)
                item.Parent = _parent;
            _collection.Insert(index, item);
        }
        public void RemoveAt(int index)
        {
            T oldItem = _collection[index];
            _collection.RemoveAt(index);
            if (oldItem != null)
                oldItem.Parent = null;
        }
        public T this[int index]
        {
            get
            {
                return _collection[index];
            }
            set
            {
                T oldItem = _collection[index];
                if (value != null)
                    value.Parent = _parent;
                _collection[index] = value;
                if (oldItem != null)
                    oldItem.Parent = null;
            }
        }
        #endregion
        #region ICollection<T> Members
        public void Add(T item)
        {
            if (item != null)
                item.Parent = _parent;
            _collection.Add(item);
        }
        public void Clear()
        {
            foreach (T item in _collection)
            {
                if (item != null)
                    item.Parent = null;
            }
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
        public int Count
        {
            get { return _collection.Count; }
        }
        public bool IsReadOnly
        {
            get { return _collection.IsReadOnly; }
        }
        public bool Remove(T item)
        {
            bool b = _collection.Remove(item);
            if (item != null)
                item.Parent = null;
            return b;
        }
        #endregion
        #region IEnumerable<T> Members
        public IEnumerator<T> GetEnumerator()
        {
            return _collection.GetEnumerator();
        }
        #endregion
        #region IEnumerable Members
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return (_collection as System.Collections.IEnumerable).GetEnumerator();
        }
        #endregion
    }
