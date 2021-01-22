    private void FindFilesRec(
        string newRootFolder,
        Predicate<FileInfo> fileMustBeProcessedP,
        Action<FileInfo> processFile)
    {
        var rootDir = new DirectoryInfo(newRootFolder);
        foreach (var file in from f in rootDir.GetFiles()
                             where fileMustBeProcessedP(f)
                             select f)
        {
            processFile(file);
        }
        foreach (var dir in from d in rootDir.GetDirectories()
                            where (d.Attributes & FileAttributes.ReparsePoint) != FileAttributes.ReparsePoint
                            select d)
        {
            FindFilesRec(
                dir.FullName,
                fileMustBeProcessedP,
                processFile);
        }
    }
