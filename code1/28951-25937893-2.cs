    public static bool IsImplementerOfRawGeneric(this Type type, Type toCheck)
    {
        if(type.IsClass)
        {
           return false;
        }
        return toCheck.GetInterfaces().Any(interfaceType =>
        {
            var current = interfaceType.IsGenericType ? 
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
