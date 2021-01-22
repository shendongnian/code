    static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
    {
        String resourceName = new AssemblyName(args.Name).Name + ".dll";
        using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
        {
            Byte[] assemblyData = new Byte[stream.Length];
            stream.Read(assemblyData, 0, assemblyData.Length);
            return Assembly.Load(assemblyData);
        }
    }
