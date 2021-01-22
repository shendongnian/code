    namespace Watcher
    {
        class Program
        {
            private const string Directory = @"C:\Temp";
            private static FileSystemWatcher _fileWatcher;
            private static FileSystemWatcher _dirWatcher;
    
            static void Main(string[] args)
            {
                 _fileWatcher = new FileSystemWatcher(Directory);
                 _fileWatcher.IncludeSubdirectories = true;
                 _fileWatcher.NotifyFilter = NotifyFilters.FileName;
                 _fileWatcher.EnableRaisingEvents = true;
                 _fileWatcher.Deleted += WatcherActivity;
                _dirWatcher = new FileSystemWatcher(Directory);
                _dirWatcher.IncludeSubdirectories = true;
                _dirWatcher.NotifyFilter = NotifyFilters.DirectoryName;
                _dirWatcher.EnableRaisingEvents = true;
                _dirWatcher.Deleted += WatcherActivity;
    
                Console.ReadLine();
            }
    
            static void WatcherActivity(object sender, FileSystemEventArgs e)
            {
                if(sender == _dirWatcher)
                {
                    Console.WriteLine("Directory:{0}",e.FullPath);
                }
                else
                {
                    Console.WriteLine("File:{0}",e.FullPath);
                }
            }
        }
    }
