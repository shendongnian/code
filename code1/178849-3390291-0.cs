    class Program
    {
        static void Main(string[] args)
        {
            System.IO.FileSystemWatcher watcher = new System.IO.FileSystemWatcher(@"c:\", "*.txt");
            watcher.Created += new System.IO.FileSystemEventHandler(watcher_Created);
            watcher.EnableRaisingEvents = true;
            Console.ReadLine();
        }
    
        static void watcher_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            Console.WriteLine(string.Format("{0} was created at {1:hh:mm:ss}", e.FullPath, DateTime.Now));
        }
    }
