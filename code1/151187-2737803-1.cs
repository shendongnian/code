    public static class Extensions
    {
      public static bool In<T>(this T value, params T[] items)
      {
          return items.Contains(value);
      }
    }
    
    if (v.In(1,2,3,5)) { /* do stuff */ }
