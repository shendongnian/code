    static string lookupPath = @"c:\otherbin";
    static void Main(string[] args)
    {
        AppDomain.CurrentDomain.AssemblyResolve += 
            new ResolveEventHandler(CurrentDomain_AssemblyResolve);
    }
    static Assembly CurrentDomain_AssemblyResolve(object sender, 
                                                  ResolveEventArgs args)
    {
        var assemblyname = args.Name.Split(',')[0];
        var assemblyFileName = Path.Combine(lookupPath, assemblyname + ".dll");
        var assembly = Assembly.LoadFrom(assemblyFileName);
        return assembly;
    }
