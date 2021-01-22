    public static bool HasFlags<T>(this T value, T flags) where T : struct
    {
        if (!(value is Enum))
        {
            throw new ArgumentException();
        }
        // ...
    }
