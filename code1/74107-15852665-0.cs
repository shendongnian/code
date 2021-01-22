    public class DualDictionary<TKey1, TKey2, TValue> : IEnumerable<KeyValuePair<Tuple<TKey1, TKey2>, TValue>>
    {
        Dictionary<TKey1, KeyValuePair<TKey2, TValue>> _firstKeys;
        Dictionary<TKey2, KeyValuePair<TKey1, TValue>> _secondKeys;
        public int Count
        {
            get
            {
                if (_firstKeys.Count != _secondKeys.Count)
                    throw new Exception("somewhere logic went wrong and your data got corrupt");
                return _firstKeys.Count;
            }
        }
        public ICollection<TKey1> Key1s
        {
            get { return _firstKeys.Keys; }
        }
        public ICollection<TKey2> Key2s
        {
            get { return _secondKeys.Keys; }
        }
        public IEnumerable<TValue> Values
        {
            get { return this.Select(kvp => kvp.Value); }
        }
        public DualDictionary(IEqualityComparer<TKey1> comparer1 = null, IEqualityComparer<TKey2> comparer2 = null)
        {
            _firstKeys = new Dictionary<TKey1, KeyValuePair<TKey2, TValue>>(comparer1);
            _secondKeys = new Dictionary<TKey2, KeyValuePair<TKey1, TValue>>(comparer2);
        }
        public bool ContainsKey1(TKey1 key)
        {
            return ContainsKey(key, _firstKeys);
        }
        private static bool ContainsKey<S, T>(S key, Dictionary<S, KeyValuePair<T, TValue>> dict)
        {
            return dict.ContainsKey(key);
        }
        public bool ContainsKey2(TKey2 key)
        {
            return ContainsKey(key, _secondKeys);
        }
        public TValue GetValueByKey1(TKey1 key)
        {
            return GetValueByKey(key, _firstKeys);
        }
        private static TValue GetValueByKey<S, T>(S key, Dictionary<S, KeyValuePair<T, TValue>> dict)
        {
            return dict[key].Value;
        }
        public TValue GetValueByKey2(TKey2 key)
        {
            return GetValueByKey(key, _secondKeys);
        }
        public bool TryGetValueByKey1(TKey1 key, out TValue value)
        {
            return TryGetValueByKey(key, _firstKeys, out value);
        }
        private static bool TryGetValueByKey<S, T>(S key, Dictionary<S, KeyValuePair<T, TValue>> dict, out TValue value)
        {
            KeyValuePair<T, TValue> otherPairing;
            bool b = TryGetValue(key, dict, out otherPairing);
            value = otherPairing.Value;
            return b;
        }
        private static bool TryGetValue<S, T>(S key, Dictionary<S, KeyValuePair<T, TValue>> dict,
                                              out KeyValuePair<T, TValue> otherPairing)
        {
            return dict.TryGetValue(key, out otherPairing);
        }
        public bool TryGetValueByKey2(TKey2 key, out TValue value)
        {
            return TryGetValueByKey(key, _secondKeys, out value);
        }
        public bool Add(TKey1 key1, TKey2 key2, TValue value)
        {
            if (ContainsKey1(key1) || ContainsKey2(key2))   // very important
                return false;
            AddOrUpdate(key1, key2, value);
            return true;
        }
        // dont make this public; a dangerous method used cautiously in this class
        private void AddOrUpdate(TKey1 key1, TKey2 key2, TValue value)
        {
            _firstKeys[key1] = new KeyValuePair<TKey2, TValue>(key2, value);
            _secondKeys[key2] = new KeyValuePair<TKey1, TValue>(key1, value);
        }
        public bool UpdateKey1(TKey1 oldKey, TKey1 newKey)
        {
            return UpdateKey(oldKey, _firstKeys, newKey, (key1, key2, value) => AddOrUpdate(key1, key2, value));
        }
        private static bool UpdateKey<S, T>(S oldKey, Dictionary<S, KeyValuePair<T, TValue>> dict, S newKey,
                                            Action<S, T, TValue> updater)
        {
            KeyValuePair<T, TValue> otherPairing;
            if (!TryGetValue(oldKey, dict, out otherPairing) || ContainsKey(newKey, dict))
                return false;
            Remove(oldKey, dict);
            updater(newKey, otherPairing.Key, otherPairing.Value);
            return true;
        }
        public bool UpdateKey2(TKey2 oldKey, TKey2 newKey)
        {
            return UpdateKey(oldKey, _secondKeys, newKey, (key1, key2, value) => AddOrUpdate(key2, key1, value));
        }
        public bool UpdateByKey1(TKey1 key, TValue value)
        {
            return UpdateByKey(key, _firstKeys, (key1, key2) => AddOrUpdate(key1, key2, value));
        }
        private static bool UpdateByKey<S, T>(S key, Dictionary<S, KeyValuePair<T, TValue>> dict, Action<S, T> updater)
        {
            KeyValuePair<T, TValue> otherPairing;
            if (!TryGetValue(key, dict, out otherPairing))
                return false;
            updater(key, otherPairing.Key);
            return true;
        }
        public bool UpdateByKey2(TKey2 key, TValue value)
        {
            return UpdateByKey(key, _secondKeys, (key1, key2) => AddOrUpdate(key2, key1, value));
        }
        public bool RemoveByKey1(TKey1 key)
        {
            return RemoveByKey(key, _firstKeys, _secondKeys);
        }
        private static bool RemoveByKey<S, T>(S key, Dictionary<S, KeyValuePair<T, TValue>> keyDict,
                                              Dictionary<T, KeyValuePair<S, TValue>> valueDict)
        {
            KeyValuePair<T, TValue> otherPairing;
            if (!TryGetValue(key, keyDict, out otherPairing))
                return false;
            if (!Remove(key, keyDict) || !Remove(otherPairing.Key, valueDict))
                throw new Exception("somewhere logic went wrong and your data got corrupt");
            return true;
        }
        private static bool Remove<S, T>(S key, Dictionary<S, KeyValuePair<T, TValue>> dict)
        {
            return dict.Remove(key);
        }
        public bool RemoveByKey2(TKey2 key)
        {
            return RemoveByKey(key, _secondKeys, _firstKeys);
        }
        public void Clear()
        {
            _firstKeys.Clear();
            _secondKeys.Clear();
        }
        public IEnumerator<KeyValuePair<Tuple<TKey1, TKey2>, TValue>> GetEnumerator()
        {
            if (_firstKeys.Count != _secondKeys.Count)
                throw new Exception("somewhere logic went wrong and your data got corrupt");
            return _firstKeys.Select(kvp => new KeyValuePair<Tuple<TKey1, TKey2>, TValue>(Tuple.Create(kvp.Key, kvp.Value.Key),
                                                                                          kvp.Value.Value)).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
