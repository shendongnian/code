    AppDomain.CurrentDomain.AssemblyResolve += (s, args) =>
    {
        // Note: Requires a using statement for System.Reflection and System.Diagnostics
        Assembly assembly = Assembly.GetExecutingAssembly();
        List<string> embeddedResources = new List<string>(assembly.GetManifestResourceNames());
        string assemblyName = new AssemblyName(args.Name).Name;
        string fileName = string.Format("{0}.dll", assemblyName);
        string resourceName = embeddedResources.Where(ern => ern.EndsWith(fileName)).FirstOrDefault();
        if (!string.IsNullOrWhiteSpace(resourceName))
        {
            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                Byte[] assemblyData = new Byte[stream.Length];
                stream.Read(assemblyData, 0, assemblyData.Length);
                var test = Assembly.Load(assemblyData);
                string namespace_ = test.GetTypes().Where(t => t.Name == assemblyName).Select(t => t.Namespace).FirstOrDefault();
    #if DEBUG
                Debug.WriteLine(string.Format("\tNamespace for '{0}' is '{1}'", fileName, namespace_));
    #endif
                return Assembly.Load(assemblyData);
            }
        }
        return null;
    }; 
