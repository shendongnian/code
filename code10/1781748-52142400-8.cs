    public static IEnumerable<FileInfo> GetFilesDepthFirst(this DirectoryInfo root,
        string dirPattern = "*", string filePattern = "*.*")
    {
        var stack = new Stack<DirectoryInfo>();
        stack.Push(root);
        while (stack.Count > 0)
        {
            var current = stack.Pop();
            IList<FileInfo> files = new List<FileInfo>();
            IList<DirectoryInfo> dirs = new List<DirectoryInfo>();
            try
            {
                foreach (FileInfo file in current.EnumerateFiles(searchPattern: filePattern))
                    files.Add(file);
            }
            catch (UnauthorizedAccessException) { }
            catch (PathTooLongException) { }
            foreach (FileInfo file in files)
                yield return file;
            try
            {
                foreach (DirectoryInfo dir in current.EnumerateDirectories(searchPattern: dirPattern))
                    dirs.Add(dir);
            }
            catch (UnauthorizedAccessException) { }
            catch (PathTooLongException) { }
            foreach (DirectoryInfo dir in dirs)
                stack.Push(dir);
        }
    }
