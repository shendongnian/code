    public class BiDictionary<TKey1, TKey2> : IEnumerable<Tuple<TKey1, TKey2>>
    {
        Dictionary<TKey1, TKey2> _forwards;
        Dictionary<TKey2, TKey1> _reverses;
        public int Count
        {
            get
            {
                if (_forwards.Count != _reverses.Count)
                    throw new Exception("somewhere logic went wrong and your data got corrupt");
                return _forwards.Count;
            }
        }
        public ICollection<TKey1> Key1s
        {
            get { return _forwards.Keys; }
        }
        public ICollection<TKey2> Key2s
        {
            get { return _reverses.Keys; }
        }
        public BiDictionary(IEqualityComparer<TKey1> comparer1 = null, IEqualityComparer<TKey2> comparer2 = null)
        {
            _forwards = new Dictionary<TKey1, TKey2>(comparer1);
            _reverses = new Dictionary<TKey2, TKey1>(comparer2);
        }
        public bool ContainsKey1(TKey1 key)
        {
            return ContainsKey(key, _forwards);
        }
        private static bool ContainsKey<S, T>(S key, Dictionary<S, T> dict)
        {
            return dict.ContainsKey(key);
        }
        public bool ContainsKey2(TKey2 key)
        {
            return ContainsKey(key, _reverses);
        }
        public TKey2 GetValueByKey1(TKey1 key)
        {
            return GetValueByKey(key, _forwards);
        }
        private static T GetValueByKey<S, T>(S key, Dictionary<S, T> dict)
        {
            return dict[key];
        }
        public TKey1 GetValueByKey2(TKey2 key)
        {
            return GetValueByKey(key, _reverses);
        }
        public bool TryGetValueByKey1(TKey1 key, out TKey2 value)
        {
            return TryGetValue(key, _forwards, out value);
        }
        private static bool TryGetValue<S, T>(S key, Dictionary<S, T> dict, out T value)
        {
            return dict.TryGetValue(key, out value);
        }
        public bool TryGetValueByKey2(TKey2 key, out TKey1 value)
        {
            return TryGetValue(key, _reverses, out value);
        }
        public bool Add(TKey1 key1, TKey2 key2)
        {
            if (ContainsKey1(key1) || ContainsKey2(key2))   // very important
                return false;
            AddOrUpdate(key1, key2);
            return true;
        }
        public void AddOrUpdateByKey1(TKey1 key1, TKey2 key2)
        {
            if (!UpdateByKey1(key1, key2))
                AddOrUpdate(key1, key2);
        }
        // dont make this public; a dangerous method used cautiously in this class
        private void AddOrUpdate(TKey1 key1, TKey2 key2)
        {
            _forwards[key1] = key2;
            _reverses[key2] = key1;
        }
        public void AddOrUpdateKeyByKey2(TKey2 key2, TKey1 key1)
        {
            if (!UpdateByKey2(key2, key1))
                AddOrUpdate(key1, key2);
        }
        public bool UpdateKey1(TKey1 oldKey, TKey1 newKey)
        {
            return UpdateKey(oldKey, _forwards, newKey, (key1, key2) => AddOrUpdate(key1, key2));
        }
        private static bool UpdateKey<S, T>(S oldKey, Dictionary<S, T> dict, S newKey, Action<S, T> updater)
        {
            T otherKey;
            if (!TryGetValue(oldKey, dict, out otherKey) || ContainsKey(newKey, dict))
                return false;
            Remove(oldKey, dict);
            updater(newKey, otherKey);
            return true;
        }
        public bool UpdateKey2(TKey2 oldKey, TKey2 newKey)
        {
            return UpdateKey(oldKey, _reverses, newKey, (key1, key2) => AddOrUpdate(key2, key1));
        }
        public bool UpdateByKey1(TKey1 key1, TKey2 key2)
        {
            return UpdateByKey(key1, _forwards, _reverses, key2, (k1, k2) => AddOrUpdate(k1, k2));
        }
        private static bool UpdateByKey<S, T>(S key1, Dictionary<S, T> forwards, Dictionary<T, S> reverses, T key2,
                                              Action<S, T> updater)
        {
            T otherKey;
            if (!TryGetValue(key1, forwards, out otherKey) || ContainsKey(key2, reverses))
                return false;
            if (!Remove(otherKey, reverses))
                throw new Exception("somewhere logic went wrong and your data got corrupt");
            updater(key1, key2);
            return true;
        }
        public bool UpdateByKey2(TKey2 key2, TKey1 key1)
        {
            return UpdateByKey(key2, _reverses, _forwards, key1, (k1, k2) => AddOrUpdate(k2, k1));
        }
        public bool RemoveByKey1(TKey1 key)
        {
            return RemoveByKey(key, _forwards, _reverses);
        }
        private static bool RemoveByKey<S, T>(S key, Dictionary<S, T> keyDict, Dictionary<T, S> valueDict)
        {
            T otherKey;
            if (!TryGetValue(key, keyDict, out otherKey))
                return false;
            if (!Remove(key, keyDict) || !Remove(otherKey, valueDict))
                throw new Exception("somewhere logic went wrong and your data got corrupt");
            return true;
        }
        private static bool Remove<S, T>(S key, Dictionary<S, T> dict)
        {
            return dict.Remove(key);
        }
        public bool RemoveByKey2(TKey2 key)
        {
            return RemoveByKey(key, _reverses, _forwards);
        }
        public void Clear()
        {
            _forwards.Clear();
            _reverses.Clear();
        }
        public IEnumerator<Tuple<TKey1, TKey2>> GetEnumerator()
        {
            if (_forwards.Count != _reverses.Count)
                throw new Exception("somewhere logic went wrong and your data got corrupt");
            foreach (var item in _forwards)
                yield return Tuple.Create(item.Key, item.Value);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
