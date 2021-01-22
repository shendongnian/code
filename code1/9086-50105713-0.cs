      public static class ListWithDuplicateExtensions
      {
        public static void Add<TKey, TValue>(this List<KeyValuePair<TKey, TValue>> collection, TKey key, TValue value)
        {
          var element = new KeyValuePair<TKey, TValue>(key, value);
          collection.Add(element);
        }
    
        public static int TryGetValue<TKey, TValue>(this List<KeyValuePair<TKey, TValue>> collection, TKey key, out IEnumerable<TValue> values)
        {
          values = collection.Where(pair => pair.Key.Equals(key)).Select(pair => pair.Value);
          return values.Count();
        }
      }
