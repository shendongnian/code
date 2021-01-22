    private static Queue<DirectoryInfo>directoryQueue = new Queue<DirectoryInfo>();
    private void DeleteEmpty(DirectoryInfo directory)
    {
        directoryQueue.Enqueue(directory)
        while(directoryQueue.Count > 0)
        {
        var current = directoryQueue.Dequeue();
        foreach (var d in current.GetDirectories())
        {
            directoryQueue.Enqueue(d);
        }
        if (directory.GetFileSystemInfos().Length == 0)
        {
            try
            {
                directory.Delete();
            }
            catch (Exception)
            {
                // Already gone, no permission, not empty, et cetera
            }
        }
        }
    }
