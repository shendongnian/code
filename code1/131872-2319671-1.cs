    Type type = new List<string>().GetType();
    if (type.IsGenericType) 
    {
        var genericTypeDefinition = type.GetGenericTypeDefinition();
                    
        if (genericTypeDefinition.GetInterfaces()
                    .Any( t => t.IsGenericType && 
                               t.GetGenericTypeDefinition() == typeof(IEnumerable<>)))
        {
            return type.GetGenericArguments()[0];
        }
    }
