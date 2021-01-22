    public static IEnumerable<string> EnumerateDirectoriesRecursive(string directoryPath)
    {
        return EnumerateFileSystemEntries(directoryPath).Where(e => e.isDirectory).Select(e => e.EntryPath);
    }
    
    public static IEnumerable<string> EnumerateFilesRecursive(string directoryPath)
    {
        return EnumerateFileSystemEntries(directoryPath).Where(e => !e.isDirectory).Select(e => e.EntryPath);
    }
    
    public static IEnumerable<(string EntryPath, bool isDirectory)> EnumerateFileSystemEntries(string directoryPath)
    {
        Stack<string> directoryStack = new Stack<string>(new[] { directoryPath });
    
        while (directoryStack.Any())
        {
            foreach (string fileSystemEntry in Directory.EnumerateFileSystemEntries(directoryStack.Pop()))
            {
                bool isDirectory = (File.GetAttributes(fileSystemEntry) & (FileAttributes.Directory | FileAttributes.ReparsePoint)) == FileAttributes.Directory;
    
                yield return (fileSystemEntry, isDirectory);
    
                if (isDirectory)
                    directoryStack.Push(fileSystemEntry);
            }
        }
    }
