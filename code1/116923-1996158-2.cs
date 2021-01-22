    public static string CombinePaths(params string[] paths)
    {
        if (paths == null)
        {
            throw new ArgumentNullException("paths");
        }
        return paths.Aggregate(Path.Combine);
    }
