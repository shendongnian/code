    private void getEmbeddedResourceNamespaces()
    {
        // Note: Requires a using statement for System.Reflection and System.Diagnostics.
        Assembly assembly = Assembly.GetExecutingAssembly();
        List<string> embeddedResourceNames = new List<string>(assembly.GetManifestResourceNames());
        foreach (string resourceName in embeddedResourceNames)
        {
            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                Byte[] assemblyData = new Byte[stream.Length];
                stream.Read(assemblyData, 0, assemblyData.Length);
                try
                {
                    var test = Assembly.Load(assemblyData);
                    foreach (Type type in test.GetTypes())
                    {
                        Debug.WriteLine(string.Format("\tNamespace for '{0}' is '{1}'", type.Name, type.Namespace));
                    }
                }
                catch 
                {
                }
            }
        }
    }
