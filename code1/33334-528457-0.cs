    static class DictionaryExtensions
    {
        public static TValue Find<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            Func<TValue, bool> predicate)
        {
            return dictionary.Values.Single(predicate);
        }
    }
