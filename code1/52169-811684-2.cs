    public static bool Is<T>(this object myObject)
    {
        return (myObject is T);
    }
    
    public static bool IsNot<T>(this object myObject)
    {
        return !(myObject is T);
    }
