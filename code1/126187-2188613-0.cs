No looping, maps a Dictionary{T, U} to Dictionary{T, object} in constant time:
    class DictionaryWrapper<T, U> : IDictionary<T, object>
    {
        readonly Dictionary<T, U> inner;
        public DictionaryWrapper(Dictionary<T, U> wrapped)
        {
            this.inner = wrapped;
        }
        #region IDictionary<T,object> Members
        public void Add(T key, object value) { inner.Add(key, (U)value); }
        public bool ContainsKey(T key) { return inner.ContainsKey(key); }
        public ICollection<T> Keys { get { return inner.Keys; } }
        public bool Remove(T key) { return inner.Remove(key); }
        public bool TryGetValue(T key, out object value)
        {
            U temp;
            bool res = inner.TryGetValue(key, out temp);
            value = temp;
            return res;
        }
        public ICollection<object> Values { get { return inner.Values.Select(x => (object)x).ToArray(); } }
        public object this[T key]
        {
            get { return inner[key]; }
            set { inner[key] = (U)value; }
        }
        #endregion
        #region ICollection<KeyValuePair<T,object>> Members
        public void Add(KeyValuePair<T, object> item) { inner.Add(item.Key, (U)item.Value); }
        public void Clear() { inner.Clear(); }
        public bool Contains(KeyValuePair<T, object> item) { return inner.Contains(new KeyValuePair<T, U>(item.Key, (U)item.Value)); }
        public void CopyTo(KeyValuePair<T, object>[] array, int arrayIndex) { throw new NotImplementedException(); }
        public int Count { get { return inner.Count; } }
        public bool IsReadOnly { get { return false; } }
        public bool Remove(KeyValuePair<T, object> item) { return inner.Remove(item.Key); }
        #endregion
        #region IEnumerable<KeyValuePair<T,object>> Members
        public IEnumerator<KeyValuePair<T, object>> GetEnumerator()
        {
            foreach (var item in inner)
            {
                yield return new KeyValuePair<T, object>(item.Key, item.Value);
            }
        }
        #endregion
        #region IEnumerable Members
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            foreach (var item in inner)
            {
                yield return new KeyValuePair<T, object>(item.Key, item.Value);
            }
        }
        #endregion
    }
With a few more generic params, you can generalize this class further so that it maps a Dictionary{A, B} to a Dictionary{C, D}.
