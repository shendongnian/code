    var objs = AppDomain.CurrentDomain.GetAssemblies()
                               .SelectMany(assembly => assembly.GetTypes())
                               .Where(x => x.IsClass && !x.IsInterface && !x.IsAbstract && x.IsSubclassOf(typeof(BasePermissionClass))).ToList();
    
        foreach(Type obj in objs)
        {
            container.RegisterType(obj, new InjectionConstructor());
        }
