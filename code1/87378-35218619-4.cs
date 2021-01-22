    public static String GetAbsolutePath(String relativePath)
    {
        return GetAbsolutePath(null, relativePath)
    }
    public static String GetAbsolutePath(String basePath, String relativePath)
    {
        if (relativePath == null)
            return null;
        if (basePath == null)
            basePath = Path.GetFullPath("."); // quick way of getting current working directory
        else
            basePath = GetAbsolutePath(basePath, null); // to be REALLY sure ;)
        String path;
        // specific for windows paths starting on \ - they need the drive added to them.
        // I constructed this piece like this for possible Mono support.
        if (!Path.IsPathRooted(relativePath) || "\\".Equals(Path.GetPathRoot(relativePath)))
        {
            if (relativePath.StartsWith(Path.DirectorySeparatorChar.ToString()))
                path = Path.Combine(Path.GetPathRoot(basePath), relativePath.TrimStart(Path.DirectorySeparatorChar));
            else
                path = Path.Combine(basePath, relativePath);
        }
        else
            path = relativePath;
        // resolves any internal "..\" to get the true full path.
        return Path.GetFullPath(path);
    }
