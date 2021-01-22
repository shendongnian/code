    public class ReadOnlyDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private IDictionary<TKey, TValue> _innerDictionary;
        public ReadOnlyDictionary(IDictionary<TKey, TValue> innerDictionary)
        {
            this._innerDictionary = innerDictionary;
        }
        
        public void Add(TKey key, TValue value)
        {
            throw new NotImplementedException();
        }
        public bool Remove(TKey key)
        {
            throw new NotImplementedException();
        }
        public void Add(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }
        public void Clear()
        {
            throw new NotImplementedException();
        }
        public bool IsReadOnly
        {
            get { return true; }
        }
        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return _innerDictionary.GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _innerDictionary.GetEnumerator();
        }
    }
