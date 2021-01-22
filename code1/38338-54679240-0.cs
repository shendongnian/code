    namespace System.Collections.Generic.CustomExtensions
    {
        public static class DictionaryCustomExtensions
        {
            public static TValue GetValueSafely<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
            {
                TValue value = default(TValue);
                dictionary.TryGetValue(key, out value);
                return value;
            }
        }
    }
