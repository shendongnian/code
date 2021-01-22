    public class Comparer<T> : IEqualityComparer<T>
    {
        private readonly Func<T, int> _hashFunction;
        public Comparer(Func<T, int> hashFunction)
        {
            _hashFunction = hashFunction;
        }
        public bool Equals(T first, T second)
        {
            return _hashFunction(first) == _hashFunction(second);
        }
        public int GetHashCode(T value)
        {
            return _hashFunction(value);
        }
    }
