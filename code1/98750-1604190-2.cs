    public void DeleteDirectories(DirectoryInfo directoryInfo)
    {
        Stack<DirectoryInfo> directories = new Stack<DirectoryInfo>();
        directories.Push(directoryInfo);
        while (directories.Count > 0)
        {
            var current = directories.Peek();
            foreach (var d in current.GetDirectories())
            {
                directories.Push(d);
            }
            if (current != directories.Peek())
                continue;
            current.Delete();
            directories.Pop();
        }
    }
