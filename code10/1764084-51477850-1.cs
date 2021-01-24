    public static class DictionaryExt
    {
        public static Dictionary<TKey, TValue> AddRange<TKey, TValue>(
            this Dictionary<TKey, TValue> self, 
            IEnumerable<KeyValuePair<TKey, TValue>> items)
        {
            foreach (var item in items)
            {
                self[item.Key] = item.Value;
            }
            return self;
        }
    }
