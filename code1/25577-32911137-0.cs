    public static IEnumerable<string> Split(this DirectoryInfo path)
    {
        if (path == null) 
            throw new ArgumentNullException("path");
        if (path.Parent != null)
            foreach(var d in Split(path.Parent))
                yield return d;
        yield return path.Name;
    }
