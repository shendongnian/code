    public static List<FileSystemInfo> GetAllFilesAndDirectories ( string dir ) {
      int i = 0; 
      List<DirectoryInfo> toProcess = new List<DirectoryInfo>();
      List<FileSystemInfo> list = new List<FileSystemInfo>();
      toProcess.Add(new DirectoryInfo(dir));
      while ( i < toProcess.Count ) { 
        DirectoryInfo curDir = toProcess[i];
        foreach ( FileSystemInfo curFile in curDir.GetFileSystemInfos() ) {
          list.Add(curFile);
          DirectoryInfo maybe = curFile as DirectoryInfo;
          if ( maybe != null ) {
            toProcess.Add(maybe);
          }
        i++;
      }
      return list;
    }
      FileSystemInfo[] all = info.GetFileSystemInfos("*", SearchOptions.AllDirectories);
      return new List<FileSystemInfo>(all);
    }
