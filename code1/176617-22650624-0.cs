    bool isDirectory = Path.GetExtension(e.FullPath) == string.Empty;
    
    
    if (e.ChangeType != WatcherChangeTypes.Deleted)
    {
        isDirectory = Directory.Exists(e.FullPath);
    }
