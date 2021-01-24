    public struct Maybe<T>
    {
        public T Value { get; }
        public bool IsEmpty => Value == null;
        public Maybe(T value)
        {
            Value = value;
        }
        public static implicit operator Maybe<T>(T value)
        {
            return new Maybe<T>(value);
        }
    }
