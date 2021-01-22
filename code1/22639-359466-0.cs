    /// <summary>
    /// Returns an array of Types that implement the supplied generic interface in the
    /// current AppDomain.
    /// </summary>
    /// <param name="interfaceType">Type of generic interface implemented</param>
    /// <param name="excludeAbstractTypes">Exclude Abstract class types in the search</param>
    /// <param name="excludeInterfaceTypes">Exclude Interface class types in the search</param>
    /// <returns>Array of Types that implement the supplied generic interface</returns>
    /// <remarks>
    /// History.<br/>
    /// 11/12/2008      davide       Created method.<br/>
    /// 11/12/2008      davide       Altered method to use a two LINQ query pass.<br/>
    /// 11/12/2008      davide       Altered method to use optimised combined LINQ query.<br/>
    /// 12/12/2008      davide       Altered method and replaced FullName criteria match with GetGenericTypeDefinition.<br/>
    /// </remarks>
    public static Type[] GetTypesImplementingGenericInterface(Type interfaceType, bool excludeAbstractTypes, bool excludeInterfaceTypes)
    {
    	if (!interfaceType.IsGenericType)
    	{
    		throw new ArgumentException("Supplied interface is not a Generic type");
    	}
    
    	if (interfaceType.ContainsGenericParameters)
    	{
    		interfaceType = interfaceType.GetGenericTypeDefinition();
    	}
    
    	// Use linq to find types that implement the supplied generic interface.
    	var implementingTypes = from assembly in AppDomain.CurrentDomain.GetAssemblies()
    							from type in assembly.GetTypes()
    							where (type.IsAbstract != excludeAbstractTypes) || (!excludeAbstractTypes)
    							where (type.IsInterface != excludeInterfaceTypes) || (!excludeInterfaceTypes)
    							from intf in type.GetInterfaces()
    							where intf.IsGenericType && intf.GetGenericTypeDefinition() == interfaceType
    							select type;
    
    	return implementingTypes.ToArray<Type>();
    }
