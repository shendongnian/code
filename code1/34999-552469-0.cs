    if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>))
    {
        // Handle lists
        // use type.GetGenericArguments() to work out the element type
    }
