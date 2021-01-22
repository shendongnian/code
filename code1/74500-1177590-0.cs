    public static class DictionaryExtensions
    {
        public static void SafeAdd<TKey, TValue>(this Dictionary<TKey, TValue> dict, 
                                                 TKey key, TValue value)
        {
            dict[key] = value;
        }
    }
