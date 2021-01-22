            var fsw1 = new FileSystemWatcher();
            var fsw2 = new FileSystemWatcher();
            FileSystemEventHandler fsw_changed = delegate(object sender, FileSystemEventArgs e)
            {
                Console.WriteLine("{0} - {1}", (sender as FileSystemWatcher).Path, e.ChangeType);
            };
            fsw1.Changed += fsw_changed;
            fsw2.Changed += fsw_changed;
