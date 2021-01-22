    public static class NullableEx
    {
        public static bool IsNullOrDefault<T>(this T? value)
            where T : struct
        {
            return EqualityComparer<T>.Default.Equals(value.GetValueOrDefault(), default(T));
        }
    }
