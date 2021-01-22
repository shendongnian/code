    public class FixedSizeDictionaryWrapper<TKey, TValue> : IDictionary<TKey, TValue>
    {
        IDictionary<TKey, TValue> _realDictionary;
        public FixedSizeDictionaryWrapper(IDictionary<TKey, TValue> realDictionary)
        {
            _realDictionary = realDictionary;
        }
        public TValue this[TKey key]
        {
            get { return _realDictionary[key]; }
            set 
            {
                if (!_realDictionary.Contains(key))
                    throw new InvalidOperationException();
                _realDictionary[key] = value;
            }
        }
        // Implement Add so it always throws InvalidOperationException
        // implement all other dictionary methods to forward onto _realDictionary
    }
