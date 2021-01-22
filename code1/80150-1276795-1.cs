    static bool IsList(object obj)
    {
        Type t = obj.GetType();
        do {
            if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(List<>))
                return true;
            t = t.BaseType;
        } while (t != null);
        return false;
    }
