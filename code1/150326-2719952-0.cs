            static void Main(string[] args)
            {
                //* Create Watcher object.
                FileSystemWatcher watcher = new FileSystemWatcher(@"C:\MyFolder\");
                //* Assign event handler. 
                watcher.Created += new FileSystemEventHandler(watcher_Created);
                //* Start watching. 
                watcher.EnableRaisingEvents = true;
    
                Console.ReadLine();
            }
    
    
            static void watcher_Created(object sender, FileSystemEventArgs e)
            {
                File.Move(e.FullPath, @"C:\MyMovedFolder\" + e.Name);
            }
