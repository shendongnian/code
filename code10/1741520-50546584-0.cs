    public TreeNode EnumerateDirectory(TreeNode parentNode)
    {
        ...
    
        foreach (DirectoryInfo dir in rootDir.GetDirectories())
        {
            if (dir.Attributes.HasFlag(FileAttributes.Hidden)) continue;
            ...
        }
        ...
    }
