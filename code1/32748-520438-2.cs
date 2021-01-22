    // #1
    if (typeof(MyType) == anObject.GetType()) {
    // anObject is a MyType
    ...
    }
    //#2
    public static bool IsType(object obj, string type)
    {// modified from Visual C# 2005 Recipes {Apress}
    // Get the named type, use case-insensitive search, throw
    // an exception if the type is not found.
    Type t = Type.GetType(type, true, true);
    return t == obj.GetType();
    }
    //#3
    public static bool IsTypeOrSubclass(object obj, string type)
    {// modified from Visual C# 2005 Recipes {Apress}
    // Get the named type, use case-insensitive search, throw
    // an exception if the type is not found.
    Type t = Type.GetType(type, true, true);
    return t == obj.GetType() || obj.GetType().IsSubclassOf(t);
    }
