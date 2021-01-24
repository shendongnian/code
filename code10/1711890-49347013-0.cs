    public class SequenceComparer : IEqualityComparer<string[]>
    {
        public bool Equals(string[] x, string[] y)
        {
            if (ReferenceEquals(x, y))
                return true;
            if (x == null || y == null)
                return false;
            return x.SequenceEqual(y);
        }
        public int GetHashCode(string[] obj)
        {
            return obj.Aggregate(42, (c, n) => c ^ n.GetHashCode());
        }
    }
