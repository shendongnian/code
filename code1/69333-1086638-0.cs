    public static bool IsSet<T>(this T value, T flags) where T : Enum
    { 
        if (value is int)
        {
            return ((int)(object)a & (int)(object)b) == (int)(object)b);
        }
        //etc...
