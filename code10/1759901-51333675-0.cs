    static class Extensions 
    {
      public static bool IsSingleton<T>(this IEnumerable<T> items)
      {
        bool seenOne = false;
        foreach(T item in items) 
        {
          if (seenOne) return false;
          seenOne = true;
        }
        return seenOne;
      }
      public static bool IsSingleton<T>(
        this IEnumerable<T> items, Func<T, bool> predicate) =>
          items.Where(predicate).IsSingleton();
    }
