    static string lookupPath = @"c:\otherbin";
    static void Main(string[] args)
    {
        AppDomain.CurrentDomain.AssemblyResolve += 
            new ResolveEventHandler(CurrentDomain_AssemblyResolve);
    }
    static Assembly CurrentDomain_AssemblyResolve(object sender, 
                                                  ResolveEventArgs args)
    {
        var assemblyname = new AssemblyName(args.Name).Name;
        var assemblyFileName = Path.Combine(lookupPath, assemblyname + ".dll");
        var assembly = Assembly.LoadFrom(assemblyFileName);
        return assembly;
    }
