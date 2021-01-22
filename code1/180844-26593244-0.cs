        public myClass(String dir)
        {
            mDir = dir;
            Directory.CreateDirectory(mDir);
            InitFileSystemWatcher();
            Console.WriteLine("Deleting " + mDir);
            Directory.Delete(mDir, true);
        }
        private FileSystemWatcher watcher;
        private string mDir;
        private void MyErrorHandler(object sender, FileSystemEventArgs args)
        {
            // You can try to recreate the FileSystemWatcher here
            try
            {
                mWatcher.Error -= MyErrorHandler;
                mWatcher.Dispose();
                InitFileSystemWatcher();
            }
            catch (Exception)
            {
                // a bit nasty catching Exception, but you can't do much
                // but the handle should be released now 
            }
            // you might not be able to check immediately as your old FileSystemWatcher
            // is in your current callstack, but it's a start.
        }
        private void InitFileSystemWatcher()
        {
            mWatcher = new FileSystemWatcher(mDir);
            mWatcher.IncludeSubdirectories = false;
            mWatcher.EnableRaisingEvents = true;
            mWatcher.Error += MyErrorHandler;
        }
