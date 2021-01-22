    public static IEnumerable<DirectoryInfo> Ancestors(string path)
    {
        var dir = new DirectoryInfo(path);
    
        while (dir.Parent != null)
        {
            dir = dir.Parent;
            yield return dir;
        }
    }
