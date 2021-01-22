    static class DictionaryExtensions
    {
        public static TValue FindSingle<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            Func<TValue, bool> predicate)
        {
            return dictionary.Values.Single(predicate);
        }
        public static IEnumerable<TValue> Find<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            Func<TValue, bool> predicate)
        {
            return dictionary.Values.Where(predicate);
        }
    }
