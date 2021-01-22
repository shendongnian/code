         FileSystemWatcher watcher = new FileSystemWatcher(Environment.CurrentDirectory, "test.txt");
         while (true)
         {
             var changedResult =
                 watcher.WaitForChanged(WatcherChangeTypes.Changed);
             Console.WriteLine(changedResult.Name);
         }
