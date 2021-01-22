    public sealed class ReadOnlyDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private readonly IDictionary<TKey, TValue> _dictionary;
        public ReadOnlyDictionary(IDictionary<TKey, TValue> dictionary)
        {
            if (dictionary == null)
                throw new ArgumentNullException("dictionary", "Value cannot be null.");
            _dictionary = dictionary;
        }
        public bool ContainsKey(TKey key)
        {
            return _dictionary.ContainsKey(key);
        }
        public ICollection<TKey> Keys
        {
            get { return _dictionary.Keys; }
        }
        public bool TryGetValue(TKey key, out TValue value)
        {
            return _dictionary.TryGetValue(key, out value);
        }
        public ICollection<TValue> Values
        {
            get { return _dictionary.Values; }
        }
        void IDictionary<TKey, TValue>.Add(TKey key, TValue value)
        {
            throw new NotSupportedException("Dictionary is read-only.");
        }
        bool IDictionary<TKey, TValue>.Remove(TKey key)
        {
            throw new NotSupportedException("Dictionary is read-only.");
        }
        public TValue this[TKey key]
        {
            get { return _dictionary[key]; }
        }
        TValue IDictionary<TKey, TValue>.this[TKey key]
        {
            get { return _dictionary[key]; }
            set { throw new NotSupportedException("Dictionary is read-only."); }
        }
        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return _dictionary.Contains(item);
        }
        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            _dictionary.CopyTo(array, arrayIndex);
        }
        public int Count
        {
            get { return _dictionary.Count; }
        }
        void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> item)
        {
            throw new NotSupportedException("Collection is read-only.");
        }
        void ICollection<KeyValuePair<TKey, TValue>>.Clear()
        {
            throw new NotSupportedException("Collection is read-only.");
        }
        bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly
        {
            get { return true; }
        }
        bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> item)
        {
            throw new NotSupportedException("Collection is read-only.");
        }
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return _dictionary.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_dictionary).GetEnumerator();
        }
    }
