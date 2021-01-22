        private static void StartMonitoring()
        {
            //Watch the current directory for changes to the file RssChannels.xml
            var fileSystemWatcher = new FileSystemWatcher(@".\","RssChannels.xml");
            //What should happen when the file is changed
            fileSystemWatcher.Changed += fileSystemWatcher_Changed;
            //Start watching
            fileSystemWatcher.EnableRaisingEvents = true;
        }
        static void fileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            Debug.WriteLine(e.FullPath + " changed");
        }
