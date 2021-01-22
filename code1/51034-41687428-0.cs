    public static bool IsGenericList(this object Value)
    {
        var t = Value.GetType();
        return t.IsGenericType && t.GetGenericTypeDefinition() == typeof(List<>);
    }
    public static bool IsGenericList<T>(this object Value)
    {
        var t = Value.GetType();
        return t.IsGenericType && t.GetGenericTypeDefinition() == typeof(List<T>);
    }
