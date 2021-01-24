    public static IEnumerable<FileInfo> GetFilesDepthFirst(this DirectoryInfo root,
        string dirPattern = "*", string filePattern = "*.*")
    {
        var stack = new Stack<DirectoryInfo>();
        stack.Push(root);
        while (stack.Count > 0)
        {
            var current = stack.Pop();
            IEnumerable<FileInfo> files = Enumerable.Empty<FileInfo>();
            IEnumerable<DirectoryInfo> dirs = Enumerable.Empty<DirectoryInfo>();
            try
            {
    #if NET35
                dirs = current.GetDirectories(searchPattern: dirPattern);
                files = current.GetFiles(searchPattern: filePattern);
    #else
                dirs = current.EnumerateDirectories(searchPattern: dirPattern);
                files = current.EnumerateFiles(searchPattern: filePattern);                  
    #endif
            }
            catch (UnauthorizedAccessException) { }
            catch (PathTooLongException) { }
            foreach (FileInfo file in files)
                yield return file;
            foreach (DirectoryInfo dir in dirs)
                stack.Push(dir);
        }
    }
