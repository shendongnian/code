        FileSystemWatcher watcher = new FileSystemWatcher(Environment.CurrentDirectory, "test.txt");
        watcher.Changed += watcher_Changed;
        static void watcher_Changed(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine(e.FullPath);
            Console.WriteLine(e.ChangeType);
        }
