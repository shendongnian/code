    public static bool Is<T>(object myObject)
    {
        return (myObject is T);
    }
    
    public static bool IsNot<T> (object myObject)
    {
        return !(myObject is T);
    }
