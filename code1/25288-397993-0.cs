    Stack<DirectoryInfo> dirs = new Stack<DirectoryInfo>();
    FileInfo mostRecent = null;
    
    dirs.Push(new DirectoryInfo("C:\\TEMP"));
    
    while (dirs.Count > 0) {
        DirectoryInfo current = dirs.Pop();
    
        Array.ForEach(current.GetFiles(), delegate(FileInfo f)
        {
            if (mostRecent == null || mostRecent.LastWriteTime < f.LastWriteTime)
                mostRecent = f;
        });
    
        Array.ForEach(current.GetDirectories(), delegate(DirectoryInfo d)
        {
            dirs.Push(d);
        });
    }
    
    Console.Write("Most recent: {0}", mostRecent.FullName);
