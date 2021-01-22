    public struct Nullable<T> where T: struct
    {
        public bool HasValue { get; }
        public T Value { get; }
    }
