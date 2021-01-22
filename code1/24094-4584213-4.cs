    static bool IsNullable<T>(T obj)
    {
        if (!typeof(T).IsGenericType)
            return false;
        	
        return typeof(T).GetGenericTypeDefinition() == typeof(Nullable<>);
    }
