      public static class IEnumerableExtensions
      {
          public static bool ExceedsThreshold<T> 
             (IEnumerable<bool> this bools, int threshold)
          { return bools.Count(b => b) > threshold; }
      }
