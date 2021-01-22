    public static List<FileInfo> GetFileList(string fileSearchPattern, string rootFolderPath)
            {
                DirectoryInfo rootDir = new DirectoryInfo(rootFolderPath);
    
                List<DirectoryInfo> dirList = new List<DirectoryInfo>(rootDir.GetDirectories("*", SearchOption.AllDirectories));
                dirList.Add(rootDir);
    
                List<FileInfo> fileList = new List<FileInfo>();
    
                foreach (DirectoryInfo dir in dirList)
                {
                    fileList.AddRange(dir.GetFiles(fileSearchPattern, SearchOption.TopDirectoryOnly));
                }
    
                return fileList;
            }
