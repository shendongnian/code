    public class KeyedCollection<TKey, TItem> : ICollection<TItem>
    {
        Func<TItem, TKey> _keySelector;
        Dictionary<TKey, TItem> _dict;
        public TItem this[TKey key]
        {
            get { return _dict[key]; }
        }
        public int Count
        {
            get { return _dict.Count; }
        }
        
        public bool IsReadOnly
        {
            get { return false; }
        }
        public KeyedCollection(Func<TItem, TKey> keySelector, IEqualityComparer<TKey> comparer = null)
        {
            if (keySelector == null)
            {
                throw new ArgumentNullException("keySelector",
                                                "you are required to provide a property selector other than null");
            }
            _keySelector = keySelector;
            // EqualityComparer<TKey>.Default is used by default if comparer is null
            _dict = new Dictionary<TKey, TItem>(comparer);
        }
        private TKey GetKeyForItem(TItem item)
        {
            return _keySelector(item);
        }
        public void Add(TItem item)
        {
            _dict[GetKeyForItem(item)] = item;
        }
        public bool ContainsKey(TKey key)
        {
            return _dict.ContainsKey(key);
        }
        public bool Contains(TItem item)
        {
            return _dict.ContainsKey(GetKeyForItem(item));
        }
        public bool RemoveKey(TKey key)
        {
            return _dict.Remove(key);
        }
        public bool Remove(TItem item)
        {
            return _dict.Remove(GetKeyForItem(item));
        }
        public void Clear()
        {
            _dict.Clear();
        }
        public void CopyTo(TItem[] array, int arrayIndex)
        {
            _dict.Values.CopyTo(array, arrayIndex);
        }
        public IEnumerator<TItem> GetEnumerator()
        {
            return _dict.Values.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
