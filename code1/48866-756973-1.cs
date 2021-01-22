    public static bool IsOrdered<T>(this IEnumerable<T> enumerable) {
      var comparer = Comparer<T>.Default;
      using ( var e = enumerable.GetEnumerator() ) {
        if ( !e.MoveNext() ) {
          return true;
        }
        var previous = e.Current;
        while (e.MoveNext()) {
          if ( comparer.Compare(previous, e.Current) > 0) {
            return false;
          }
          previous = e.Current;
        }
        return true;
      }
    }
