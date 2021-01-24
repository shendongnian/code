    public static class DictionaryExtensions
    {
        public static bool TryRemove<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, out TValue value)
        {
            value = default;
            if (dict.TryGetValue(key, out value))
                return dict.Remove(key);
            else
                return false;
        }
    }
