    string GetPropertyName<T>(T prop)
    {
        var type = typeof(T);
        if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
        {
            return type.GenericTypeArguments[0].FullName;
        }
        else
        {
            return type.FullName;
        }
    }
