    public class CustomEqualityComparer<T> : IEqualityComparer<T>
    {
        Func<T, T, bool> _comparison;
        Func<T, int> _hashCodeFactory;
        public CustomEqualityComparer(Func<T, T, bool> comparison, Func<T, int> hashCodeFactory)
        {
            _comparison = comparison;
            _hashCodeFactory = hashCodeFactory;
        }
        public bool Equals(T x, T y)
        {
            return _comparison(x, y);
        }
        public int GetHashCode(T obj)
        {
            return _hashCodeFactory(obj);
        }
    }
