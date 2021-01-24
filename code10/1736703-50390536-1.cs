    public class DeepComparer<T> : IEqualityComparer<T>
    {
        public bool Equals(T x, T y)
        {
            // Compare the Reference
            return ReferenceEquals(x, y) ||
                   // Using Default Comparer to comparer the value
                   EqualityComparer<T>.Default.Equals(x, y) ||
                   // If they both are list, Compare using Sequenece Equal
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
