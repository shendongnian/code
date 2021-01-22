    public static IEnumerable<T> Flatten<T>(IEnumerable<IEnumerable<T>> enumerable) {
      foreach ( var inner in enumerable ) {
        foreach ( var value in inner ) {
          yield return value;
        }
      }
    }
