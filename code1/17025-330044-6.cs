    public static bool AnyOf(this object mask, object flags)
    {
        return ((int)mask & (int)flags) != 0;
    }
    public static bool AllOf(this object mask, object flags)
    {
        return ((int)mask & (int)flags) == (int)flags;
    }
    public static object SetOn(this object mask, object flags)
    {
        return (int)mask | (int)flags;
    }
    etc.
