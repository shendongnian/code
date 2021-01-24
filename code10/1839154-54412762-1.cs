    public static bool IsEmpty(this IEnumerable items)
    {
      // EXERCISE: Why is this implementation bad? 
      // EXERCISE: Can you improve it?
      foreach(var item in items)
        return false;
      return true;
    }
    public static bool IsNullOrEmpty<TKey, TValue>(
      this Dictionary<TKey, TValue> dictionary, TKey key) 
      where TValue : IEnumerable
    {
      return !dictionary.ContainsKey(key) || 
        dictionary.ContainsKey(key) && dictionary[key].IsEmpty();
    }
 
