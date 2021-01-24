    private sealed class MyComparer : IEqualityComparer<HashSet<string>> {
      public bool Equals(HashSet<string> x, HashSet<string> y) {
        if (object.ReferenceEquals(x, y))
          return true;
        else if (null == x || null == y)
          return false;
        return (x.Count == y.Count) && (!x.Except(y).Any());
      }
      public int GetHashCode(HashSet<string> obj) {
        return obj == null ? -1 : obj.Count;
      }
    }
