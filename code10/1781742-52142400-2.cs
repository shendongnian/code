    public static IEnumerable<FileInfo> GetFilesDepthFirst(this DirectoryInfo root, 
        string searchPattern = "*.*", SearchOption searchOption = SearchOption.TopDirectoryOnly)
    {
        var stack = new Stack<DirectoryInfo>();
        stack.Push(root);
        while (stack.Count > 0)
        {
            var current = stack.Pop();
            foreach (FileInfo f in current.EnumerateFiles(searchPattern, searchOption))
                yield return f;
            foreach (DirectoryInfo d in current.EnumerateDirectories(searchPattern, searchOption))
                stack.Push(d);
        }
    }
