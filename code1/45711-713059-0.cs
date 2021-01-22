    public static class DictionaryExtensions
    {
        public static Merge<TKey,TVal>(this IDictionary<TKey,TVal> dictA, IDictionary<TKey,TVal> dictB)
        {
            foreach (KeyValuePair<TKey,TVal> pair in dictB)
            {
                // TODO: Check for collisions?
                dictA.Add(pair.Key, Pair.Value);
            }
        }
    }
