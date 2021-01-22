    private static IEnumerable<DirectoryInfo> GetDirs(string rootFolderPath)
    {
         DirectoryInfo rootDir = new DirectoryInfo(rootFolderPath);
         yield return rootDir;
    
         foreach(DirectoryInfo di in rootDir.GetDirectories("*", SearchOption.AllDirectories));
         {
              yield return di;
         }
         yield break;
    }
    
    public static IEnumerable<FileInfo> GetFileList(string fileSearchPattern, string rootFolderPath)
    {
         var allDirs = GetDirs(rootFolderPath);
         foreach(DirectoryInfo di in allDirs())
         {
              var files = di.GetFiles(fileSearchPattern, SearchOption.TopDirectoryOnly);
              foreach(FileInfo fi in files)
              {
                   yield return fi;
              }
         }
         yield break;
    }
