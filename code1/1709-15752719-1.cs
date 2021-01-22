    public static void Clamp<T>(ref T value)
    {
        int minimum = Enum.GetValues(typeof(T)).GetLowerBound(0);
        int maximum = Enum.GetValues(typeof(T)).GetUpperBound(0);
    
        if (Convert.ToInt32(value) < minimum) { value = (T)Enum.ToObject(typeof(T), minimum); }
        if (Convert.ToInt32(value) > maximum) { value = (T)Enum.ToObject(typeof(T), maximum); }
    }
