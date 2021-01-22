    namespace System.Collections.Generic {
      public static class ExtensionMethods {
        public static bool DictionaryEquals<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> d1, IReadOnlyDictionary<TKey, TValue> d2) {
          if (object.ReferenceEquals(d1, d2)) return true; 
          if (d1 is null != d2 is null || d1.Count != d2.Count) return false;
          foreach (var (d1key, d1value) in d1) {
            if (!d2.TryGetValue(d1key, out TValue d2value)) return false;
            if (!d1value.Equals(d2value)) return false;
          }
          return true;
        }
      }
    }
