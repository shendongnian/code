    public static void ForEachPair<T1,T2>(
      this IEnumerable<T1> source1, 
      IEnumerable<T2> source2,
      Action<T1,T2> del) {
      using ( var e1 = source1.GetEnumerator() ) {
        using ( var e2 = source2.GetEnumerator() ) {
          if ( e1.MoveNext() && e2.MoveNext() ) {
            del(e1.Current, e2.Current);
          }
        }
      }
    }
