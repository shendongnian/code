    bool CheckAllBaseTypes(Type type)
    {
        var baseType = type.BaseType;
        if (baseType  == null)
            return false;            
    
        if (baseType.IsGenericType 
              && baseType.GetGenericTypeDefinition() == typeof(Listener<>))
            return true;
    
        return CheckAllBaseTypes(baseType);
    }
    
    var listeners = AppDomain.CurrentDomain.GetAssemblies()
        .SelectMany(assembly => assembly.GetTypes())
        .Where(x => x.IsClass && !x.IsAbstract && CheckAllBaseTypes(x))
        .ToList();
