    public static String GetAbsolutePath(String path)
    {
        return GetAbsolutePath(null, path);
    }
    public static String GetAbsolutePath(String baseResolvePath, String path)
    {
        if (path == null)
            return null;
        if (baseResolvePath == null)
            baseResolvePath = Path.GetFullPath("."); // quick way of getting current working directory
        else
            baseResolvePath = GetAbsolutePath(null, baseResolvePath); // to be REALLY sure ;)
        String finalPath;
        // specific for windows paths starting on \ - they need the drive added to them.
        // I constructed this piece like this for possible Mono support.
        if (!Path.IsPathRooted(path) || "\\".Equals(Path.GetPathRoot(path)))
        {
            if (path.StartsWith(Path.DirectorySeparatorChar.ToString()))
                finalPath = Path.Combine(Path.GetPathRoot(baseResolvePath), path.TrimStart(Path.DirectorySeparatorChar));
            else
                finalPath = Path.Combine(baseResolvePath, path);
        }
        else
            finalPath = path;
        // resolves any internal "..\" to get the true full path.
        return Path.GetFullPath(finalPath);
    }
