    public static IEnumerable<FileInfo> EnumerateFiles_Recursive(this DirectoryInfo directory, string searchPattern, SearchOption searchOption, Func<DirectoryInfo, Exception, bool> handleExceptionAccess)
    {
        Queue<DirectoryInfo> subDirectories = new Queue<DirectoryInfo>();
        IEnumerable<FileSystemInfo> entries = null;
    
        // Try to get an enumerator on fileSystemInfos of directory
        try
        {
            entries = directory.EnumerateFileSystemInfos(searchPattern, SearchOption.TopDirectoryOnly);
        }
        catch (Exception e)
        {
            // If there's a callback delegate and this delegate return true, we don't throw the exception
            if (handleExceptionAccess == null || !handleExceptionAccess(directory, e))
                throw;
            // If the exception wasn't throw, we make entries reference an empty collection
            entries = EmptyFileSystemInfos;
        }
    
        // Yield return file entries of the directory and enqueue the subdirectories
        foreach (FileSystemInfo entrie in entries)
        {
            if (entrie is FileInfo)
                yield return (FileInfo)entrie;
            else if (entrie is DirectoryInfo)
                subDirectories.Enqueue((DirectoryInfo)entrie);
        }
    
        // If recursive search, we make recursive call on the method to yield return entries of the subdirectories.
        if (searchOption == SearchOption.AllDirectories)
        {
            DirectoryInfo subDir = null;
            while (subDirectories.Count > 0)
            {
                subDir = subDirectories.Dequeue();
                foreach (FileInfo file in subDir.EnumerateFiles_Recursive(searchPattern, searchOption, handleExceptionAccess))
                {
                    yield return file;
                }
            }
        }
        else
            subDirectories.Clear();
    }
