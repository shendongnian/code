    public class IndexableDictionary<T1, T2> : Dictionary<T1, T2>
    {
        private SortedDictionary<int, T1> _sortedKeys;
    
        public IndexableDictionary()
        {
            _sortedKeys = new SortedDictionary<int, T1>();
        }
        public new void Add(T1 key, T2 value)
        {
            _sortedKeys.Add(_sortedKeys.Count + 1, key);
            base.Add(key, value);
        }
    
        private IEnumerable<KeyValuePair<T1, T2>> Enumerable()
        {
            foreach (T1 key in _sortedKeys.Values)
            {
                yield return new KeyValuePair<T1, T2>(key, this[key]);
            }
        }
    
        public new IEnumerator<KeyValuePair<T1, T2>> GetEnumerator()
        {
            return Enumerable().GetEnumerator();
        }
    
        public KeyValuePair<T1, T2> this[int index]
        {
            get
            {
                return new KeyValuePair<T1, T2> (_sortedKeys[index], base[_sortedKeys[index]]);
            }
            set
            {
                _sortedKeys[index] = value.Key;
                base[value.Key] = value.Value;
            }
    
        }
    
    
    }
