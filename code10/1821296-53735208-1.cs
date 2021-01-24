    public static class Extensions
    {
       // checks if both keys exists and returns true or false
       // returns a result if valid
       public static bool TryGetValue<TKey1, TKey2, TValue>(this Dictionary<TKey1, Dictionary<TKey2, TValue>> dict, TKey1 key1, TKey2 key2, out TValue result)
       {
          if(dict == null)
             throw new ArgumentNullException(nameof(dict));
          result = default;
    
          return dict.TryGetValue(key1, out var nestedDict) && nestedDict.TryGetValue(key2, out result);
       }
    }
