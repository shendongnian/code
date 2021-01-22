    static class DictionaryExtensions {
       public static TValue GetValueOrDefault<TKey, TValue>(this Dictionary<TKey,TValue> dic, TKey key, Func<TValue, TKey> valueGenerator) {
          TValue val;
          if (dic.TryGetValue(key, out val))
             return val;
          return valueGenerator(key);
       }
    }
