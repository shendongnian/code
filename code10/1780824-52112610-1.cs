    static bool IsDirectSubclassOfRawGeneric(Type parent, Type toCheck)
    {
    	return toCheck.BaseType.IsGenericType && parent == toCheck.BaseType.GetGenericTypeDefinition();
    }
    ...
    Console.WriteLine(IsDirectSubclassOfRawGeneric(typeof(HtSecureInstancePage<>), typeof(InstancePage)));
