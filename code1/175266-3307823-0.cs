    static bool IsBaseType<T>()
    {
        var t = typeof(T);
        do
        {
            if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(BaseType<>))
            {
                return true;
            }
            t = t.BaseType;
        }
        while (t != null);
        return false;
    }
