    public static bool IsType(object obj, string type)
    {
    // Get the named type, use case-insensitive search, throw
    // an exception if the type is not found.
    Type t = Type.GetType(type, true, true);
    return t == obj.GetType() || obj.GetType().IsSubclassOf(t);
    }
