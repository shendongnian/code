    class CircularList<T> : IList<T>
    {
        static IEnumerable<T> ToEnumerator(CircularList<T> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                yield return list[i];
            }
        }
        IList<T> arr;
        public int Shift { get; private set; }
        public CircularList(IList<T> arr, int shift)
        {
            this.arr = arr;
            this.Shift = shift;
        }
        int shiftIndex(int baseIndex)
        {
            return (baseIndex + Shift) % arr.Count;
        }
        #region IList<T> Members
        public int IndexOf(T item) { throw new NotImplementedException(); }
        public void Insert(int index, T item) { throw new NotImplementedException(); }
        public void RemoveAt(int index) { throw new NotImplementedException(); }
        public T this[int index]
        {
            get { return arr[shiftIndex(index)]; }
            set { arr[shiftIndex(index)] = value; }
        }
        #endregion
        #region ICollection<T> Members
        public void Add(T item) { throw new NotImplementedException(); }
        public void Clear() { throw new NotImplementedException(); }
        public bool Contains(T item) { throw new NotImplementedException(); }
        public void CopyTo(T[] array, int arrayIndex) { throw new NotImplementedException(); }
        public int Count { get { return arr.Count; } }
        public bool IsReadOnly { get { throw new NotImplementedException(); } }
        public bool Remove(T item) { throw new NotImplementedException(); }
        #endregion
        #region IEnumerable<T> Members
        public IEnumerator<T> GetEnumerator()
        {
            return ToEnumerator(this).GetEnumerator();
        }
        #endregion
        #region IEnumerable Members
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return ToEnumerator(this).GetEnumerator();
        }
        #endregion
    }
