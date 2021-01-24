    public static class Extensions
    {
        public static TValue GetValueOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> dict,TKey key)
          =>  dict.TryGetValue(key, out var value) ? value : default(TValue);
    }
