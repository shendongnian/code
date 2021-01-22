    public static string GetFileNameWithoutExtension(string path)
    {
        path = GetFileName(path);
        if (path == null)
        {
            return null;
        }
        int length = path.LastIndexOf('.');
        if (length == -1)
        {
            return path;
        }
        return path.Substring(0, length);
    }
