    public static class Extensions
    {
       public static void ReplaceKey<T, U>(this Dictionary<T, U> source, T key, T newKey)
       {
          if(!source.TryGetValue(key, out var value))
             throw new ArgumentException("Key does not exist", nameof(key));
          source.Remove(key);
          source.Add(newKey, value);
       }
    }
