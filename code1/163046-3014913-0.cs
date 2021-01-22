    public static class DictionaryExtensions
    {
        public static bool ShouldAddValue<TKey, TValue>(this Dictionary<TKey, TValue> someDictionary, TKey id, TValue actual)
        {
            TValue stored;
            return (!someDictionary.TryGetValue(id, out stored) || !stored.Equals(actual)); 
        }
    }
