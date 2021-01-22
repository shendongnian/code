    public static class SortedListExtensions
    {
     public static bool AddIfNotContains<K, V>(this IDictionary<K, V> dictionary, K key, V value)
     {
      if (!dictionary.ContainsKey(key))
      {
       dictionary.Add(key, value);
       return true;
      }
      return false;
     }
    }
 
