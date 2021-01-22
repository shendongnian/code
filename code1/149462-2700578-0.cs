    static Type GetNonEmittedType(Type t)
    {
        if (t.Assembly is AssemblyBuilder)
            return GetNonEmittedType(t.BaseType);
        return t;
    }
