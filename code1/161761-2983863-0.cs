    public class SpecificFileWatcher
    {
      public string FileToTest { get; set; }
    
      private readonly FileSystemWatcher iWatcher;
      
    
      public class SpecificFileWatcher(FileSystemWatcher watcher)
      {
        iWatcher = watcher;
        iWatcher.Changed += iWatcher_Changed; //whatever event you need here
      }
    
      //eventhandler for watcher
      public ...
      {
        if(e.FileName == FileToTest)
          Console.WriteLine("file found");
      }
    }
