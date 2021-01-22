    static bool IsIEnumerable(Type type)
    {
        return type.IsGenericType
            && type.GetGenericTypeDefinition() == typeof(IEnumerable<>);
    }
    
    static Type GetIEnumerableImpl(Type type)
    {
        // Get IEnumerable implementation. Either type is IEnumerable<T> for some T, 
        // or it implements IEnumerable<T> for some T. We need to find the interface.
        if (IsIEnumerable(type))
            return type;
        Type[] t = type.FindInterfaces((m, o) => IsIEnumerable(m), null);
        Debug.Assert(t.Length == 1);
        return t[0];
    }
    
