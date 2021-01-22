     using System.Collections.Generic;
    public class MultiMapSet<TKey, TValue>
    {
        private readonly Dictionary<TKey, HashSet<TValue>> _ht = new Dictionary<TKey, HashSet<TValue>>();
        public void Add(TKey key, TValue value)
        {
            HashSet<TValue> valueSet;
            if (_ht.TryGetValue(key, out valueSet))
            {
                valueSet.Add(value);
            }
            else
            {
                valueSet = new HashSet<TValue> { value };
                _ht.Add(key, valueSet);
            }
        }
        public bool HasValue(TKey key, TValue value)
        {
            HashSet<TValue> valueSet;
            if (_ht.TryGetValue(key, out valueSet))
            {
                return valueSet.Contains(value);
            }
            return false;
        }
        public HashSet<TValue> GetValues(TKey key)
        {
            HashSet<TValue> valueSet;
            _ht.TryGetValue(key, out valueSet);
            return valueSet;
        }
        public void Remove(TKey key, TValue value)
        {
            HashSet<TValue> valueSet;
            if (!_ht.TryGetValue(key, out valueSet))
            {
                return;
            }
            if (valueSet.Contains(value))
            {
                valueSet.Remove(value);
            }
        }
    }
