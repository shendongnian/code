    public static bool HasFlags<T>(this T value, T flags) where T : struct
    {
        if (!(value is Enum))
        {
            throw new ArgumentException();
        }
        return EnumHelper<T>.HasFlags(value, flags);
    }
    private class EnumHelper<T> where T : struct
    {
        static EnumHelper()
        {
            if (!typeof(Enum).IsAssignableFrom(typeof(T))
            {
                throw new InvalidOperationException(); // Or something similar
            }
        }
        internal static HasFlags(T value, T flags)
        {
            ...
        }
    }
