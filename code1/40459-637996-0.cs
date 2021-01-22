    foreach (Type interfaceType in obj.GetType().GetInterfaces())
    {
        if (interfaceType.IsGenericType
            && interfaceType.GetGenericTypeDefinition() == typeof(IEnumerable<>))
        {
            Type itemType = interfaceType.GetGenericArguments()[0];
            if(!itemType.IsValueType) continue;
            Console.WriteLine("IEnumerable-of-" + itemType.FullName);
        }
    }
