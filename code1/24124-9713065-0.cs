    public bool IsNullable(object obj)
    {
        Type t = obj.GetType();
        return t.IsGenericType 
            && t.GetGenericTypeDefinition() == typeof(Nullable<>);
    }
