    public static class MyLinqMethods
    {
      public static bool HasDuplicates<T>(this IEnumerable<T> sequence)
      {
          return sequence.GroupBy(n => n).Any(c => c.Count() > 1);
      }
    }
