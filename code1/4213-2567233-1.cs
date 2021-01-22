    public static string GetDirectoryPath(this Assembly assembly)
    {
        string filePath = new Uri(assembly.CodeBase).LocalPath;
        return Path.GetDirectoryName(filePath);            
    }
