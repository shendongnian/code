    public class KeyedCollection<TKey, TItem> : ICollection<TItem>
    {
        MemberInfo _keyInfo;
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
        public ICollection<TKey> Keys
        {
            get { return _dict.Keys; }
        }
        private ICollection<TItem> Items
        {
            get { return _dict.Values; }
        }
        public KeyedCollection(Expression<Func<TItem, TKey>> keySelector, IEqualityComparer<TKey> comparer = null)
        {
            var keyExpression = keySelector.Body as MemberExpression;
            if (keyExpression != null)
                _keyInfo = keyExpression.Member;
            _keySelector = keySelector.Compile();
            _dict = new Dictionary<TKey, TItem>(comparer);
        }
        private TKey GetKeyForItem(TItem item)
        {
            return _keySelector(item);
        }
        
        public bool ContainsKey(TKey key)
        {
            return _dict.ContainsKey(key);
        }
        public bool Contains(TItem item)
        {
            return ContainsKey(GetKeyForItem(item));
        }
        public bool TryGetItem(TKey key, out TItem item)
        {
            return _dict.TryGetValue(key, out item);
        }
        public void Add(TItem item)
        {
            _dict.Add(GetKeyForItem(item), item);
        }
        public void AddOrUpdate(TItem item)
        {
            _dict[GetKeyForItem(item)] = item;
        }
        public bool UpdateKey(TKey oldKey, TKey newKey)
        {
            TItem oldItem;
            if (_keyInfo == null || !TryGetItem(oldKey, out oldItem) || !SetItem(oldItem, newKey))   // important
                return false;
            RemoveKey(oldKey);
            Add(oldItem);
            return true;
        }
        private bool SetItem(TItem item, TKey key)
        {
            var propertyInfo = _keyInfo as PropertyInfo;
            if (propertyInfo != null)
            {
                if (!propertyInfo.CanWrite)
                    return false;
                propertyInfo.SetValue(item, key, null);
                return true;
            }
            var fieldInfo = _keyInfo as FieldInfo;
            if (fieldInfo != null)
            {
                if (fieldInfo.IsInitOnly)
                    return false;
                fieldInfo.SetValue(item, key);
                return true;
            }
            return false;
        }
        public bool RemoveKey(TKey key)
        {
            return _dict.Remove(key);
        }
        public bool Remove(TItem item)
        {
            return RemoveKey(GetKeyForItem(item));
        }
        public void Clear()
        {
            _dict.Clear();
        }
        public void CopyTo(TItem[] array, int arrayIndex)
        {
            Items.CopyTo(array, arrayIndex);
        }
        public IEnumerator<TItem> GetEnumerator()
        {
            return Items.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
