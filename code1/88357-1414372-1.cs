    public static class EnumHelper
    {
        public static T[] GetEnumValues<T>()
            where T: struct
        {
            Debug.Assert(typeof(T).IsEnum);
            return (T[])Enum.GetValues(typeof(T));
        }
    }
