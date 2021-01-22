    if (value != null)
    {
        Type valueType = value.GetType();
        if (valueType.IsGenericType)
        {
            Type baseType = valueType.GetGenericTypeDefinition();
            if (baseType == typeof(KeyValuePair<,>))
            {
                Type[] argTypes = baseType.GetGenericArguments();
                // now process the values
            }
        }
    }
