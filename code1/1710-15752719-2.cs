    public static T Clamp<T>(T value)
    {
        int minimum = Enum.GetValues(typeof(T)).GetLowerBound(0);
        int maximum = Enum.GetValues(typeof(T)).GetUpperBound(0);
    
        if (Convert.ToInt32(value) < minimum) { return (T)Enum.ToObject(typeof(T), minimum); }
        if (Convert.ToInt32(value) > maximum) { return (T)Enum.ToObject(typeof(T), maximum); }
        return value;
    }
