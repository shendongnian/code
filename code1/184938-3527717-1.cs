    public static IEnumerable<FileInfo> GetFilesByExtensions(this DirectoryInfo dir, params string[] extensions)
    {
        if (extensions == null) 
             throw new ArgumentNullException("extensions");
        IEnumerable<FileInfo> files = Enumerable.Empty<FileInfo>();
        foreach(string ext in extensions)
        {
           files = files.Concat(dir.GetFiles(ext));
        }
        return files;
    }
