    if (field.PropertyType.IsGenericType)
    {
        var typeArguments = field.PropertyType.GetGenericArguments();
        typesToCast.Add(typeArguments[0].Name);
    }
    else
    {
        typesToCast.Add(field.PropertyType.Name);
    }
