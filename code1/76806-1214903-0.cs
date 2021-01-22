    static string NormalizeFolder(string path)
    {
      DirectoryInfo dir = new DirectoryInfo(path);
    
      return dir.Root
        .GetDirectories("*", SearchOption.AllDirectories)
        .First(d => d.FullName.ToUpper() == path.ToUpper())
        .FullName;      
    }
