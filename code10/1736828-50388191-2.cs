    public struct MyNullable<T> where T : struct
    {
        public T Value { get; set; }
        // ... other code
        public static implicit operator MyNullable<T>(T value)
        {
            return new MyNullable<T> { Value = value };
        }
    }
