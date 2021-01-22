    foreach (var i in type.GetInterfaces())
    {
        if (i.IsGenericType && i.GetGenericTypeDefinition() == genericType)
        {
            return true;
        }
    }
