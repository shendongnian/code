    public IEnumerable<Type> FindSubClassesOf<TBaseType>()
    {	
        var baseType = typeof(TBaseType);
        var assembly = baseType.Assembly;
	
        return assembly.GetTypes().Where(t => t.IsSubclassOf(baseType));
    }
