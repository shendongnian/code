    public class MaxCountDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private readonly Dictionary<TKey, TValue> _dictionary;
        private readonly object _lock;
    
        public MaxCountDictionary(int maxCount) : this(maxCount, EqualityComparer<TKey>.Default) { }
    
        public MaxCountDictionary(int maxCount, IEqualityComparer<TKey> equalityComparer)
        {
            _lock = new object();
            MaxCount = maxCount;
            _dictionary = new Dictionary<TKey, TValue>(equalityComparer);
        }
    
        public int MaxCount { get; }
    
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => _dictionary.GetEnumerator();
    
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    
        public void Add(KeyValuePair<TKey, TValue> item) => Add(item.Key, item.Value);
    
        public void Clear()
        {
            lock (_lock)
            {
                _dictionary.Clear();
            }
        }
    
        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            lock (_lock)
            {
                return ((IDictionary<TKey, TValue>) _dictionary).Contains(item);
            }
        }
    
        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            lock (_lock)
            {
                ((IDictionary<TKey, TValue>) _dictionary).CopyTo(array, arrayIndex);
            }
        }
    
        public bool Remove(KeyValuePair<TKey, TValue> item) => Remove(item.Key);
    
        public int Count
        {
            get
            {
                lock (_lock)
                {
                    return _dictionary.Count;
                }
            }
        }
    
        public bool IsReadOnly => ((IDictionary<TKey, TValue>) _dictionary).IsReadOnly;
    
        public bool ContainsKey(TKey key)
        {
            lock (_lock)
            {
                return _dictionary.ContainsKey(key);
            }
        }
    
        public void Add(TKey key, TValue value)
        {
            lock (_lock)
            {
                if (_dictionary.Count < MaxCount) _dictionary.Add(key, value);
            }
        }
    
        public bool Remove(TKey key)
        {
            lock (_lock)
            {
                return _dictionary.Remove(key);
            }
        }
    
        public bool TryGetValue(TKey key, out TValue value)
        {
            lock (_lock)
            {
                return _dictionary.TryGetValue(key, out value);
            }
        }
    
        public TValue this[TKey key]
        {
            get
            {
                lock (_lock)
                {
                    return _dictionary[key];
                }
            }
            set
            {
                lock (_lock)
                {
                    if (_dictionary.ContainsKey(key) || _dictionary.Count < MaxCount) _dictionary[key] = value;
                }
            }
        }
    
        public ICollection<TKey> Keys
        {
            get
            {
                lock (_lock)
                {
                    return _dictionary.Keys.ToArray();
                }
            }
        }
    
        public ICollection<TValue> Values
        {
            get
            {
                lock (_lock)
                {
                    return _dictionary.Values.ToArray();
                }
            }
        }
    
        public void AddOrUpdate(TKey key, TValue value, Func<TKey, TValue, TValue> updateValueFactory)
        {
            lock (_lock)
            {
                if (_dictionary.ContainsKey(key))
                    _dictionary[key] = updateValueFactory(key, value);
                else if (_dictionary.Count < MaxCount) _dictionary[key] = value;
            }
        }
    }
