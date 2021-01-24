    public static IEnumerable<FileInfo> GetFilesDepthFirst(this DirectoryInfo root, string searchPattern = "*.*")
    {
        var stack = new Stack<DirectoryInfo>();
        stack.Push(root);
        while (stack.Count > 0)
        {
            var current = stack.Pop();
            foreach (FileInfo f in current.EnumerateFiles(searchPattern))
                yield return f;
            foreach (DirectoryInfo d in current.EnumerateDirectories(searchPattern))
                stack.Push(d);
        }
    }
