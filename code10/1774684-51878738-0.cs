    public class ListComparer : IEqualityComparer<List<float?>> {
      public bool Equals(List<float?> x, List<float?> y) {
        return Enumerable.SequenceEqual(x, y);
      }
      public int GetHashCode(List<float?> obj) {
        return obj == null ? -1 : obj.Count;
      }
    }
