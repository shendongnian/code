      public static class IEnumerableExtensions
      {
          public static bool ExceedsThreshold<T> 
             (this IEnumerable<bool> bools, int threshold)
          { return bools.Count(b => b) > threshold; }
      }
