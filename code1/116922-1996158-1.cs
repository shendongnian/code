    public static string CombinePaths(string path1, params string[] paths)
    {
        if (path1 == null)
        {
            throw new ArgumentNullException("path1");
        }
        if (paths == null)
        {
            throw new ArgumentNullException("paths");
        }
        return paths.Aggregate(path1, (acc, p) => Path.Combine(acc, p));
    }
