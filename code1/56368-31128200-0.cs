    public class SequenceEqualityComparer<T> : IEqualityComparer<IEnumerable<T>>
    {
        public bool Equals(IEnumerable<T> x, IEnumerable<T> y)
        {
            return x.SequenceEqual(y);
        }
        public int GetHashCode(IEnumerable<T> obj)
        {
            return unchecked(obj.Aggregate(397, (x, y) => x * 31 + y.GetHashCode()));
        }
    }
