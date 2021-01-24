    public class DeepComparer<T> : IEqualityComparer<T>
    {
        public bool Equals(T x, T y)
        {
            return ReferenceEquals(x, y) ||
                   Equals(x, y) ||
                   x is IEnumerable enumerableX &&
                   y is IEnumerable enumerableY &&
                   enumerableX.Cast<object>().SequenceEqual(enumerableY.Cast<object>());
        }
        public int GetHashCode(T obj)
        {
            unchecked
            {
                return obj is IEnumerable enumerable
                    ? enumerable.Cast<object>()
                        .Select(e => e.GetHashCode())
                        .Aggregate(17, (a, b) => 23 * a + b)
                    : obj.GetHashCode();
            }
        }
    }
