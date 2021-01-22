    public string GetEmbeddedResource(string fullyQulifiedResourceName)
    {
        var assembly = Assembly.GetExecutingAssembly();
        // NOTE resourceName is of the format "Namespace.Class.File.extension";
        
        using (Stream stream = assembly.GetManifestResourceStream(fullyQulifiedResourceName))
        using (StreamReader reader = new StreamReader(stream))
        {
            string result = reader.ReadToEnd();
        }
    }
