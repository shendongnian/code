    public class SubArray<T> : IEnumerable<T> {
       private T[] _original;
       private int _start;
       public SubArray(T[] original, int start, int len) {
          _original = original;
          _start = start;
          Length = len;
       }
       public T this[int index] {
          get {
             if (index < 0 || index >= Length) throw new IndexOutOfRangeException();
             return _original[_start + index];
          }
       }
       public int Length { get; private set; }
       public IEnumerator<T> GetEnumerator() {
          for (int i = 0; i < Length; i++) {
            yield return _original[_start + i];
          }
       }
       IEnumerator IEnumerable.GetEnumerator() {
          return GetEnumerator();
       }
    }
