    public static class DictionaryExtensions
    {
        public static Nullable<TValue> GetValueOrNull<TKey, TValue>(this Dictionary<TKey, TValue> Dictionary, TKey key)
            where TValue : struct
        {
            TValue result;
            if (Dictionary.TryGetValue(key, out result))
                return result;
            else
                return null;
        }
    }
