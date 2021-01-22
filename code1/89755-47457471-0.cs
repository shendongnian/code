    public class EnumerableComparer<T> : EqualityComparer<IEnumerable<T>>
    {
        private int _accuracy;
        private IEqualityComparer<T> _comparer;
        public EnumerableComparer()
            : this(-1)
        { }
        public EnumerableComparer(int accuracy)
            : this(accuracy, null)
        { }
        public EnumerableComparer(IEqualityComparer<T> elementEqualityComparer)
            : this(-1, elementEqualityComparer)
        { }
        public EnumerableComparer(int accuracy, IEqualityComparer<T> elementEqualityComparer)
        {
            if (accuracy < 0)
                accuracy = 4;
            _accuracy = accuracy;
            _comparer = elementEqualityComparer ?? EqualityComparer<T>.Default;
        }
        public override bool Equals(IEnumerable<T> x, IEnumerable<T> y)
        {
            if (ReferenceEquals(x, y))
                return true;
            if (ReferenceEquals(x, null))
                return false;
            if (ReferenceEquals(y, null))
                return false;
            return x.SequenceEqual(y, _comparer);
        }
        public override int GetHashCode(IEnumerable<T> obj)
        {
            if (ReferenceEquals(obj, null))
                return -1;
            var count = (obj as ICollection<T>)?.Count ?? 1;
            var hashCode = count * 49297;
            foreach (var item in obj.Take(_accuracy))
            {
                hashCode += _comparer.GetHashCode(item) * 17123;
            }
            return hashCode;
        }
    }
