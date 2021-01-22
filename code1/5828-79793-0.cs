    // Setup event handler to resolve assemblies
    AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve += new ResolveEventHandler(CurrentDomain_ReflectionOnlyAssemblyResolve);
    
    Assembly a = System.Reflection.Assembly.ReflectionOnlyLoadFrom(filename);
    a.GetTypes();
    // process types here
    
    // method later in the class:
    static Assembly CurrentDomain_ReflectionOnlyAssemblyResolve(object sender, ResolveEventArgs args)
    {
        return System.Reflection.Assembly.ReflectionOnlyLoad(args.Name);
    }
