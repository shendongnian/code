        public class Comparer<T> : IEqualityComparer<T>
        {
            private readonly Func<T, T, bool> _equalityComparer;
            public Comparer(Func<T, T, bool> equalityComparer)
            {
                _equalityComparer = equalityComparer;
            }
             
            public bool Equals(T first, T second)
            {
                return _equalityComparer(first, second);
            }
            public int GetHashCode(T value)
            {
                return value.GetHashCode();
            }
        }
