    public static string GetPathForKey(this FileInfo File)
    {
        return File.FullName.ToUpperInvariant();
    }
    public static string GetDirectoryForKey(this FileInfo File)
    {
        return File.DirectoryName.ToUpperInvariant();
    }
