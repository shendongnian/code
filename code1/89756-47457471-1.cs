    public class EnumerableEqualityComparer<T> : IEqualityComparer<IEnumerable<T>>
    {
        private static readonly Lazy<IEqualityComparer<IEnumerable<T>>> Lazy = new Lazy<IEqualityComparer<IEnumerable<T>>>(() => new EnumerableEqualityComparer<T>());
        private int accuracy;
        private IEqualityComparer<T> comparer;
        public EnumerableEqualityComparer()
            : this(-1)
        {
        }
        public EnumerableEqualityComparer(int accuracy)
            : this(accuracy, null)
        {
        }
        public EnumerableEqualityComparer(IEqualityComparer<T> elementEqualityComparer)
            : this(-1, elementEqualityComparer)
        {
        }
        public EnumerableEqualityComparer(int accuracy, IEqualityComparer<T> elementEqualityComparer)
        {
            if (accuracy < 0)
            {
                accuracy = 4;
            }
            this.accuracy = accuracy;
            comparer = elementEqualityComparer ?? EqualityComparer<T>.Default;
        }
        public static IEqualityComparer<IEnumerable<T>> Default { get; private set; } = Lazy.Value;
        public bool Equals(IEnumerable<T> x, IEnumerable<T> y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }
            if (ReferenceEquals(x, null)
                || ReferenceEquals(y, null))
            {
                return false;
            }
            return x.SequenceEqual(y, comparer);
        }
        public int GetHashCode(IEnumerable<T> obj)
        {
            if (ReferenceEquals(obj, null))
            {
                return -1;
            }
            var count = (obj as ICollection<T>)?.Count ?? 1;
            var hashCode = count * 49297;
            foreach (var item in obj.Take(accuracy))
            {
                hashCode += comparer.GetHashCode(item) * 17123;
            }
            return hashCode;
        }
    }
