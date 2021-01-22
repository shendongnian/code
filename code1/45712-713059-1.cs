    public static class DictionaryExtensions
    {
        public static IDictionary<TKey,TVal> Merge<TKey,TVal>(this IDictionary<TKey,TVal> dictA, IDictionary<TKey,TVal> dictB)
        {
            IDictionary<TKey,TVal> output = new Dictionary<TKey,TVal>(dictA);
            foreach (KeyValuePair<TKey,TVal> pair in dictB)
            {
                // TODO: Check for collisions?
                output.Add(pair.Key, Pair.Value);
            }
    
            return output;
        }
    }
