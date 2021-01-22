    foreach (Type interfaceType in type.GetInterfaces())
    {
        if (interfaceType.IsGenericType &&
            interfaceType.GetGenericTypeDefinition()
            == typeof(IList<>))
        {
            Type itemType = type.GetGenericArguments()[0];
            // do something...
            break;
        }
    }
