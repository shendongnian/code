    public class MaxFinder<T> where T : IComparable<T> {
       public T FindMax(IEnumerable<T> items) {
          T result = default(T);
          bool first = true;
          foreach (T item in items) {
             if (first) {
                result = item;
                first = false;
             } else {
                if (item.CompareTo(result) > 0) {
                   result = item;
                }
             }
          }
          return result;
       }
    }
