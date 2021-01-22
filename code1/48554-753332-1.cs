    public static class Helper {
       public static IEnumerable<T> Intersperse<T>(this IEnumerable<T> source, T element) {
          using(var i = source.GetEnumerator()) {
             if (i.MoveNext()) yield return i.Current;
             while(i.MoveNext()) {
                yield return element;
                yield return i.Current;
             }
          }
       }
    }
