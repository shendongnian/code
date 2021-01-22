      private static void WatcherError(object source, ErrorEventArgs e)
      {
         watcher = new FileSystemWatcher();//You might want to do a method and to setup all config...
         while (!watcher.EnableRaisingEvents)
         {
            try
            {
               watcher = new FileSystemWatcher();//You might want to do a method and to setup all config...
            }
            catch
            {
               System.Threading.Thread.Sleep(30000); //Wait for retry 30 sec.
            }
         }
      }
