    public static class IDictionaryExtensions
    {
        public static IEnumerable<(TKey, TValue)> Tuples<TKey, TValue>(
            this IDictionary<TKey, TValue> dict)
        {
            foreach (KeyValuePair<TKey, TValue> kvp in dict)
                yield return (kvp.Key, kvp.Value);
        }
    }
