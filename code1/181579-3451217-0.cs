    public static IEnumerable<string> GetSpecificLines(this DirectoryInfo dir, string fileSearchPattern, Func<string, bool> linePredicate)
    {
        FileInfo[] files = dir.GetFiles(fileSearchPattern);
    
        return files
            .SelectMany(f => File.ReadAllLines(f.FullName))
            .Where(linePredicate);
    }
