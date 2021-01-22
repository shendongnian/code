    public static bool IsImplementerOfRawGeneric(this Type type, Type toCheck)
    {
        if (toCheck.GetTypeInfo().IsClass)
        {
            return false;
        }
        return type.GetInterfaces().Any(interfaceType =>
        {
            var current = interfaceType.GetTypeInfo().IsGenericType ?
                        interfaceType.GetGenericTypeDefinition() : interfaceType;
            return current == toCheck;
        });
    }
	
    public static bool IsSubTypeOfRawGeneric(this Type type, Type toCheck)
	{
        return type.IsInterface ?
              IsImplementerOfRawGeneric(type, toCheck)
		    : IsSubclassOfRawGeneric(type, toCheck);
	}
