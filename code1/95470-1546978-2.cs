    public static List<FileSystemInfo> GetAllFilesAndDirectories ( string dir ) {
      DirectoryInfo info = new DirectoryInfo(dir);
      FileSystemInfo[] all = info.GetFileSystemInfos("*", SearchOptions.AllDirectories);
      return new List<FileSystemInfo>(all);
    }
