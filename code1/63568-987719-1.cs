    static void IsSet<T>(T value, T flags) where T : struct
    {
        if (!typeof(T).IsEnum)
            throw new InvalidOperationException(typeof(T).Name +" is not an enum!");
        Type t = Enum.GetUnderlyingType(typeof(T));
        if (t == typeof(int))
        {
             return (Reinterpret.AsInt(value) & Reinterpret.AsInt(flags)) != 0
        }
        else if (t == typeof(byte))
        {
             return (Reinterpret.AsByte(value) & Reinterpret.AsByte(flags)) != 0
        }
        // you get the idea...        
    }
