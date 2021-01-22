    public SDKClass()
    {
      AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(FindAssembly);
    }
    
    private Assembly FindAssembly(object sender, ResolveEventArgs args)
    {
      string assemblyPath = "c:\PathToAssembly";
      string assemblyName = args.Name.Substring(0, args.Name.IndexOf(",")) + ".dll";
      string assemblyFullName = Path.Combine(assemblyPath, assemblyName);
    
      Assembly theAssembly = Assembly.Load(assemblyFullName);
    
      return theAssembly;
    }
