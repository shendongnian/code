    static class NullableExtensions
    {
        public static T GetValue<T>(this T obj) where T : struct
        {
            return obj;
        }
        public static T GetValue<T>(this Nullable<T> obj) where T : struct
        {
            return obj.Value;
        }
    }
