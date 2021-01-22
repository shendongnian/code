    public static FileInfo SetExtension(this FileInfo fileInfo, string extension)
    {
        return new FileInfo(Path.ChangeExtension(fileInfo.FullName, extension));
    }
    public static FileInfo SetDirectory(this FileInfo fileInfo, string directory)
    {
        return new FileInfo(Path.Combine(directory, fileInfo.Name));
    }
