    public class ShortCollection<T> : IList<T>
    {
        protected Collection<T> innerCollection;
        protected int maxSize = 10;
        #region IList<T> Members
        public int IndexOf(T item)
        {
            return innerCollection.IndexOf(item);
        }
        public void Insert(int index, T item)
        {
            innerCollection.Insert(index, item);
        }
        public void RemoveAt(int index)
        {
            innerCollection.RemoveAt(index);
        }
        public T this[int index]
        {
            get
            {
                return innerCollection[index];
            }
            set
            {
                innerCollection[index] = value;
            }
        }
        #endregion
        #region ICollection<T> Members
        public void Add(T item)
        {
            innerCollection.Add(item);
        }
        public void Clear()
        {
            innerCollection.Clear();
        }
        public bool Contains(T item)
        {
            return innerCollection.Contains(item);
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            innerCollection.CopyTo(array, arrayIndex);
        }
        public int Count
        {
            get { return innerCollection.Count; }
        }
        public bool IsReadOnly
        {
            get { return false; }
        }
        public bool Remove(T item)
        {
            return innerCollection.Remove(item);
        }
        #endregion
        #region IEnumerable<T> Members
        public IEnumerator<T> GetEnumerator()
        {
            return innerCollection.GetEnumerator();
        }
        #endregion
        #region IEnumerable Members
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerCollection.GetEnumerator();
        }
        #endregion
    }
