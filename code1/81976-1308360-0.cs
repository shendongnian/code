    public static class QueryableExtensions
    {
      public static Func<bool> DeferredAny<T>(this IQueryable<T> source)
      {
        return () => source.Any();
      }
    }
