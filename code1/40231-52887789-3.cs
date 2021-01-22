    public static class NullableEx
    {
        public static bool IsNullOrDefault<T>(this T? value, T defaultValue = default(T))
            where T : struct
        {
            return EqualityComparer<T>.Default.Equals(value.GetValueOrDefault(defaultValue), defaultValue);
        }
    }
