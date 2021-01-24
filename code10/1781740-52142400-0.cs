    public static IEnumerable<FileInfo> GetFilesDepthFirst(this DirectoryInfo root)
    {
        var stack = new Stack<DirectoryInfo>();
        stack.Push(root);
        while (stack.Count > 0)
        {
            var current = stack.Pop();
            foreach (FileInfo f in current.EnumerateFiles())
                yield return f;
            foreach (DirectoryInfo d in current.EnumerateDirectories())
                stack.Push(d);
        }
    }
