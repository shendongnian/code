    public static Assembly ReflectionOnlyAssemblyResolve(
        object sender,
        ResolveEventArgs args)
    {
        return Assembly.ReflectionOnlyLoad(args.Name);
    }
