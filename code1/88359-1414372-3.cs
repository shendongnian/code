    public static class Enum<T>
    {
        static Enum()
        {
            Debug.Assert(typeof(T).IsEnum);
        }
        public static ReadOnlyCollection<T> Values = ((T[])Enum.GetValues(typeof(T))).ToList().AsReadOnly();
    }
