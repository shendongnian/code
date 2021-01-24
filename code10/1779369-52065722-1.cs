    [ClassInitialize]
    public static void ClassInitialize(TestContext testContext)
    {
        AppDomain.CurrentDomain.AssemblyResolve += AssemblyResolveEventHandler;
    }
    
    private static Assembly AssemblyResolveEventHandler(object sender, ResolveEventArgs args)
    {
        var dllName = args.Name.Split(',')[0] + ".dll";
        var assemblyPath = Path.Combine(BinDir, dllName);
        return Assembly.LoadFile(assemblyPath);
    }
