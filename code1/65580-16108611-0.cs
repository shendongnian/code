    // Note: Requires a using statement for System.Reflection.
    AppDomain.CurrentDomain.AssemblyResolve += (s, args) =>
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        List<string> embeddedResources = new List<string>(assembly.GetManifestResourceNames());
        string name = string.Format("{0}.dll", new AssemblyName(args.Name).Name);
        string resourceName = embeddedResources.Where(ern => ern.EndsWith(name)).FirstOrDefault();
        if (!string.IsNullOrWhiteSpace(resourceName))
        {
            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                Byte[] assemblyData = new Byte[stream.Length];
                stream.Read(assemblyData, 0, assemblyData.Length);
                var test = Assembly.Load(assemblyData);
                return Assembly.Load(assemblyData);
            }
        }
        return null;
    }; 
