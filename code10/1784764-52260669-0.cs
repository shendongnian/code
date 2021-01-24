    public class Watcher
    {
        public Watcher()
        {
            _queue = new BlockingCollection<string>();
        }
        private BlockingCollection<string> _queue;
        public void Start()
        {
            FileSystemWatcher fsw = new FileSystemWatcher();
            fsw.Path = @"F:\a";
            fsw.EnableRaisingEvents = true;
            fsw.IncludeSubdirectories = true;
            fsw.Created += Fsw_Created;
        }
        private void Fsw_Created(object sender, FileSystemEventArgs e)
        {
            _queue.Add(e.FullPath);
            Task.Factory.StartNew(() =>
            {
                var path = _queue.Take();
                // process the queue here
            });
        }
    }
 
