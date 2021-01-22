    public class DefaultIndexerDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private IDictionary<TKey, TValue> _dict = new Dictionary<TKey, TValue>();
        public TValue this[TKey key]
        {
            get
            {
                TValue val;
                if (!TryGetValue(key, out val))
                    return default(TValue);
                return val;
            }
            set { _dict[key] = value; }
        }
        public ICollection<TKey> Keys => _dict.Keys;
        public ICollection<TValue> Values => _dict.Values;
        public int Count => _dict.Count;
        public bool IsReadOnly => _dict.IsReadOnly;
        public void Add(TKey key, TValue value)
        {
            _dict.Add(key, value);
        }
        public void Add(KeyValuePair<TKey, TValue> item)
        {
            _dict.Add(item);
        }
        public void Clear()
        {
            _dict.Clear();
        }
        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return _dict.Contains(item);
        }
        public bool ContainsKey(TKey key)
        {
            return _dict.ContainsKey(key);
        }
        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            _dict.CopyTo(array, arrayIndex);
        }
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return _dict.GetEnumerator();
        }
        public bool Remove(TKey key)
        {
            return _dict.Remove(key);
        }
        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return _dict.Remove(item);
        }
        public bool TryGetValue(TKey key, out TValue value)
        {
            return _dict.TryGetValue(key, out value);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _dict.GetEnumerator();
        }
    }
