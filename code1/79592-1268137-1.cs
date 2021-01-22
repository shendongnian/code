    public class Adder<T> {
       public delegate T AddDelegate(T item1, T item2);
       public T AddAll(IEnumerable<T> items, AddDelegate add) {
          T result = default(T);
          foreach (T item in items) {
             result = add(result, item);
          }
          return result;
       }
    }
