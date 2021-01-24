    public class ListComparer<T> : IEqualityComparer<IEnumerable<T>> {
      public bool Equals(IEnumerable<T> x, IEnumerable<T> y) {
        return Enumerable.SequenceEqual(x, y);
      }
      public int GetHashCode(IEnumerable<T> obj) {
        return obj == null ? -1 : obj.Count();
      }
    }
