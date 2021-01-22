    static List<FileSystemInfo> GetAllFilesAndDirectories(string dir)
    {
        DirectoryInfo dirInfo = new DirectoryInfo(dir);            
        List<FileSystemInfo> allFilesAndDirectories = new List<FileSystemInfo>();
    
        allFilesAndDirectories.AddRange(dirInfo.GetFiles("*", SearchOption.AllDirectories));
        allFilesAndDirectories.AddRange(dirInfo.GetDirectories("*", SearchOption.AllDirectories));
    
        return allFilesAndDirectories;
    }
