    public static int FolderDepth(string path)
    {
        if (string.IsNullOrEmpty(path))
            return 0;
        DirectoryInfo parent = Directory.GetParent(path);
        if (parent == null)
            return 1;
        return FolderDepth(parent.FullName) + 1;
    }
