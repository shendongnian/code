    public static bool IsImplementerOfRawGeneric(this Type type, Type toCheck)
    {
        return toCheck.GetInterfaces().Any(interfaceType =>
        {
            var current = interfaceType.GetTypeInfo().IsGenericType ? 
                        interfaceType.GetGenericTypeDefinition() : interfaceType;
            return current == type;
        });
    }
	
    public static bool IsSubTypeOfRawGeneric(this Type type, Type toCheck)
	{
        return type.IsInterface ?
              IsImplementerOfRawGeneric(type, toCheck)
		    : IsSubclassOfRawGeneric(type, toCheck);
	}
