    public static class ReadOnlyDictionaryHelper
    {
        public static ReadOnlyDictionary<TKey, TValue> AsReadOnly<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            var temp = dictionary as ReadOnlyDictionary<TKey, TValue>;
            return temp ?? new ReadOnlyDictionary<TKey, TValue>(dictionary);
        }
    }
