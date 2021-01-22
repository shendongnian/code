    public static List<FileInfo> GetFilesRecursive(string b)
    {
        List<FileInfo> fileList = new List<FileInfo>();
    
        foreach( string file in Directory.GetFiles(directory, "*.*", SearchOptions.AllDirectories) )
        {
            fileList.Add(new FileInfo(file));
        }
    
        return fileList;
    }
