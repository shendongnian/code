    public static string GetCurrentExecutingDirectory(this Assembly assembly)
    {
        string filePath = new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath;
        return Path.GetDirectoryName(filePath);            
    }
