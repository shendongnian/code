    public static void DeleteEmptySubdirectories(string parentDirectory){
      System.Threading.Tasks.Parallel.ForEach(System.IO.Directory.GetDirectories(parentDirectory), directory => {
        DeleteEmptySubdirectories(directory);
        if(!System.IO.Directory.EnumerateFileSystemEntries(directory).Any()) System.IO.Directory.Delete(directory, false);
      });	
    }
