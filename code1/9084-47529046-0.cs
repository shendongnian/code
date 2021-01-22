    public class HashMapDictionary<T1, T2> : System.Collections.IEnumerable
    {
        private System.Collections.Concurrent.ConcurrentDictionary<T1, List<T2>> _keyValue = new System.Collections.Concurrent.ConcurrentDictionary<T1, List<T2>>();
        private System.Collections.Concurrent.ConcurrentDictionary<T2, List<T1>> _valueKey = new System.Collections.Concurrent.ConcurrentDictionary<T2, List<T1>>();
        public ICollection<T1> Keys
        {
            get
            {
                return _keyValue.Keys;
            }
        }
        public ICollection<T2> Values
        {
            get
            {
                return _valueKey.Keys;
            }
        }
        public int Count
        {
            get
            {
                return _keyValue.Count;
            }
        }
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }
        public List<T2> this[T1 index]
        {
            get { return _keyValue[index]; }
            set { _keyValue[index] = value; }
        }
        public List<T1> this[T2 index]
        {
            get { return _valueKey[index]; }
            set { _valueKey[index] = value; }
        }
        public void Add(T1 key, T2 value)
        {
            lock (this)
            {
                if (!_keyValue.TryGetValue(key, out List<T2> result))
                    _keyValue.TryAdd(key, new List<T2>() { value });
                else if (!result.Contains(value))
                    result.Add(value);
                if (!_valueKey.TryGetValue(value, out List<T1> result2))
                    _valueKey.TryAdd(value, new List<T1>() { key });
                else if (!result2.Contains(key))
                    result2.Add(key);
            }
        }
        public bool TryGetValues(T1 key, out List<T2> value)
        {
            return _keyValue.TryGetValue(key, out value);
        }
        public bool TryGetKeys(T2 value, out List<T1> key)
        {
            return _valueKey.TryGetValue(value, out key);
        }
        public bool ContainsKey(T1 key)
        {
            return _keyValue.ContainsKey(key);
        }
        public bool ContainsValue(T2 value)
        {
            return _valueKey.ContainsKey(value);
        }
        public void Remove(T1 key)
        {
            lock (this)
            {
                if (_keyValue.TryRemove(key, out List<T2> values))
                {
                    foreach (var item in values)
                    {
                        var remove2 = _valueKey.TryRemove(item, out List<T1> keys);
                    }
                }
            }
        }
        public void Remove(T2 value)
        {
            lock (this)
            {
                if (_valueKey.TryRemove(value, out List<T1> keys))
                {
                    foreach (var item in keys)
                    {
                        var remove2 = _keyValue.TryRemove(item, out List<T2> values);
                    }
                }
            }
        }
        public void Clear()
        {
            _keyValue.Clear();
            _valueKey.Clear();
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _keyValue.GetEnumerator();
        }
    }
