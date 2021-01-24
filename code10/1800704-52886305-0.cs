    var listeners = AppDomain.CurrentDomain.GetAssemblies()
        .SelectMany(assembly => assembly.GetTypes())
        .Where(x => x.IsClass && !x.IsInterface)
        .Where(listener => 
            !listener.IsAbstract 
            && listener.BaseType != null 
            && listener.BaseType.IsGenericType 
            && listener.BaseType.GetGenericTypeDefinition() == typeof(Listener<>))
        .ToList();
