      private static readonly FileSystemWatcher Watcher = new FileSystemWatcher();
        static void Main(string[] args)
        {
            Console.WriteLine("Watching....");
            Watcher.Path = @"D:\Temp\Watcher";
            Watcher.Changed += OnChanged;
            Watcher.EnableRaisingEvents = true;
            Console.ReadKey();
        }
       
        static void OnChanged(object sender, FileSystemEventArgs e)
        {
            try
            {
                Watcher.Changed -= OnChanged;
                Watcher.EnableRaisingEvents = false;
                Console.WriteLine($"File Changed. Name: {e.Name}");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            finally
            {
                Watcher.Changed += OnChanged;
                Watcher.EnableRaisingEvents = true;
            }
        }
