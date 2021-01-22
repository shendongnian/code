    public static void DeleteEmptySubdirectoriesSingleThread(string parentDirectory){
      foreach(string directory in System.IO.Directory.GetDirectories(parentDirectory)){
        DeleteEmptySubdirectories(directory);
        if(!System.IO.Directory.EnumerateFileSystemEntries(directory).Any()) System.IO.Directory.Delete(directory, false);
      }
    }
