    public static class Extensions
    {
       public static void ReplaceKey<T, U>(this Dictionary<T, U> source, T key)
       {
          if(!source.TryGetValue(key, out var value))
             throw new ArgumentException("Key does not exist", nameof(key));
          source.Remove(key);
          source.Add(key, value);
       }
    }
