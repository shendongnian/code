    public static partial class NullableExtension
    {
        public static bool IsNullable<T>(this Nullable<T> self) where T : struct
        {
            return true;
        }
    }
