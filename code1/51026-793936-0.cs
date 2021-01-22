    public static class IEnumerableExtensions
    {
      public static bool TryGetFirst<TSource>(this IEnumerable<TSource> source,
                                              Func<TSource, bool> predicate,
                                              out TSource first)
      {
        foreach (TSource item in source)
        {
          if (predicate(item))
          {
            first = item;
            return true;
          }
        }
        
        first = default(TSource);
        return false;
      }
    }
