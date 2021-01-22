    public static class DictionaryExtensions
    {
        public static Nullable<TValue> GetValueOrNull<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
            where TValue : struct
        {
            TValue result;
            if (dictionary.TryGetValue(key, out result))
                return result;
            else
                return null;
        }
    }
