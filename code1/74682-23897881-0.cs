    private List<FileInfo> GetLastUpdatedFileInDirectory(DirectoryInfo directoryInfo)
    {
        FileInfo[] files = directoryInfo.GetFiles();
        List<FileInfo> lastUpdatedFile = new List<FileInfo>();
        DateTime lastUpdate = DateTime.MinValue;
        foreach (FileInfo file in files)
        {
            if (file.LastAccessTime > lastUpdate)
            {
                lastUpdatedFile.Add(file);
                lastUpdate = file.LastAccessTime;
            }
        }
    
        return lastUpdatedFile;
    }
