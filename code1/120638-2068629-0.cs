    public static class Restrict
    {
        public static IRestrictable<T> Value<T>(T value) where T : IComparable<T>
        {
            return new Restricter<T>(value);
        }
        private sealed class Restricter<T> : IRestrictable<T> where T : IComparable<T>
        {
            private readonly T _value;
            internal Restricter(T value)
            {
                _value = value;
            }
            public T ToBetween(T minimum, T maximum)
            {
                // Yoink from Jon Skeet
                return _value.CompareTo(minimum) < 0
                    ? minimum
                    : _value.CompareTo(maximum) > 0 ? maximum : value;
            }
        }
    }
