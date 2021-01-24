    static bool IsDirectSubclassOfRawGeneric(Type parent, Type toCheck)
    {
    	if (toCheck.BaseType.IsGenericType && parent == toCheck.BaseType.GetGenericTypeDefinition())
    	{ 
    		return true;
    	}
    	return false;
    }
    ...
    Console.WriteLine(IsDirectSubclassOfRawGeneric(typeof(HtSecureInstancePage<>), typeof(InstancePage)));
