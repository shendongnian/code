    public static FileInfo GetNewestFile(DirectoryInfo directory) {
       return directory.GetFiles()
           .Union(directory.GetDirectories().Select(d => GetNewestFile(d)))
           .OrderByDescending(f => (f == null ? DateTime.MinValue : f.LastWriteTime))
           .FirstOrDefault();                        
    }
