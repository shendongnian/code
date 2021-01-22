    IEnumerable<Type> GetAllTypesThatImplementInterface<T>()
    {
        var @interface = typeof (T);
        return @interface.IsInterface
                   ? AppDomain.CurrentDomain.GetAssemblies()
                         .SelectMany(assembly => assembly.GetTypes())
                         .Where(type => !type.IsInterface
                                     && !type.IsAbstract 
                                     && type.GetInterfaces().Contains(@interface))
                   : new Type[] {};
    }
