    public static class IsNullable<T>
    {
        private static readonly Type type = typeof(T);
        private static readonly bool is_nullable = type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
        public static bool Result { get { return is_nullable; } }
    }
    bool is_nullable = IsNullable<int?>.Result;
