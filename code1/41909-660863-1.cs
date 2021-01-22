    public static void DisposeAll<T>(this IEnumerable<T> enumerable)
      where T : IDisposable {
      foreach ( var cur in enumerable ) { 
        cur.Dispose();
      }
    }
