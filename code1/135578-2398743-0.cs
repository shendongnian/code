    public static FileInfo GetOldestFile(string directory)
    {
        if (!Directory.Exists(directory))
            throw new ArgumentException();
        DirectoryInfo parent = new DirectoryInfo(directory);
        FileInfo[] children = parent.GetFiles();
        if (children.Length == 0)
            return null;
        FileInfo oldest = children[0];
        foreach (var child in children.Skip(1))
        {
            if (child.CreationTime < oldest.CreationTime)
                oldest = child;
        }
        return oldest;
    }
