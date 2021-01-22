    class Program
    {
        static void Main(string[] args)
        {
            MainThread.Start();
        }
    }
    public class MainThread
    {
        private static int _eventsRaised = 0;
        private static int _eventsRespondedTo = 0;
        private static bool _reload = false;
        private static readonly object _reloadLock = new object();
        //to do something once in handler, though
        //this code would go in onStart in a windows service.
        public static void Start()
        {
            WorkerThread thread1 = null;
            WorkerThread thread2 = null;
            //WorkerTimer thread1 = null;
            //WorkerTimer thread2 = null;
            //Console.WriteLine("Start: thread " + Thread.CurrentThread.ManagedThreadId);
            //watch config
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = "../../";
            watcher.Filter = "test.xml";
            watcher.EnableRaisingEvents = true;
            //subscribe to changed event. note that this event can be raised a number of times for each save of the file.
            watcher.Changed += (sender, args) => FileChanged(sender, args);
            thread1 = new WorkerThread("foo", 10);
            thread2 = new WorkerThread("bar", 15);
            //thread1 = new WorkerTimer("foo", 10);
            //thread2 = new WorkerTimer("bar", 15);
            while (true)
            {
                if (_reload)
                {
                    //create our two threads.
                    //Console.WriteLine("Start - reload: thread " + Thread.CurrentThread.ManagedThreadId);
                    //wait, to enable other file changed events to pass
                    //Console.WriteLine("Start - waiting: thread " + Thread.CurrentThread.ManagedThreadId);
                    thread1.Dispose();
                    thread2.Dispose();
                    Thread.Sleep(3000); //each thread lasts 0.5 seconds, so 3 seconds should be plenty to wait for the 
                    //LoadData function to complete.
                    Monitor.Enter(_reloadLock);
                    //GC.Collect();
                    thread1 = new WorkerThread("foo", 5);
                    thread2 = new WorkerThread("bar", 7);
                    //thread1 = new WorkerTimer("foo", 5);
                    //thread2 = new WorkerTimer("bar", 7);
                    _reload = false;
                    Monitor.Exit(_reloadLock);
                }
            }
        }
        //this event handler is called in a separate thread to Start()
        static void FileChanged(object source, FileSystemEventArgs e)
        {
            Monitor.Enter(_reloadLock);
            _eventsRaised += 1;
            //if it was more than a second since the last event (ie, it's a new save), then wait for 3 seconds (to avoid 
            //multiple events for the same file save) before processing
            if (!_reload)
            {
                //Console.WriteLine("FileChanged: thread " + Thread.CurrentThread.ManagedThreadId);
                _eventsRespondedTo += 1;
                //Console.WriteLine("FileChanged. Handled event {0} of {1}.", _eventsRespondedTo, _eventsRaised);
                //tell main thread to restart threads
                _reload = true;
            }
            Monitor.Exit(_reloadLock);
        }
    }
    public class WorkerTimer : IDisposable
    {
        private System.Threading.Timer _timer;   //the timer exists in its own separate thread pool thread.
        //private System.Timers.Timer _timer;
        private string _name = string.Empty;
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkerThread"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="interval">The interval, in seconds.</param>
        public WorkerTimer(string name, int interval)
        {
            _name = name;
            //Console.WriteLine("WorkerThread constructor: Called from thread " + Thread.CurrentThread.ManagedThreadId);
            //_timer = new System.Timers.Timer(interval * 1000);
            //_timer.Elapsed += (sender, args) => LoadData();
            //_timer.Start();
            _timer = new Timer(Tick, null, 1000, interval * 1000);
        }
        //this delegate instance does NOT run in the same thread as the thread that created the timer. It runs in its own
        //thread, taken from the ThreadPool. Hence, no need to create a new thread for the LoadData method.
        private void Tick(object state)
        {
            LoadData();
        }
        //Loads the data. Called from separate thread. Lasts 0.5 seconds.
        //
        private void LoadData()
        {
            for (int i = 0; i < 10; i++)
            {
                //Console.WriteLine(string.Format("Worker thread {0} ({2}): {1}", _name, i, Thread.CurrentThread.ManagedThreadId));
                Thread.Sleep(50);
            }
        }
        public void Stop()
        {
            //Console.WriteLine("Stop: called from thread " + Thread.CurrentThread.ManagedThreadId);
            //_timer.Stop();
            _timer.Change(Timeout.Infinite, Timeout.Infinite);
            //_timer = null;
            //_timer.Dispose();
        }
        #region IDisposable Members
        public void Dispose()
        {
            //Console.WriteLine("Dispose: called from thread " + Thread.CurrentThread.ManagedThreadId);
            //_timer.Stop();
            _timer.Change(Timeout.Infinite, Timeout.Infinite);
            //_timer = null;
            //_timer.Dispose();
        }
        #endregion
    }
    public class WorkerThread : IDisposable
    {
        private string _name = string.Empty;
        private int _interval = 0;  //thread wait interval in ms.
        private Thread _thread = null;
        private ThreadStart _job = null;
        private object _syncObject = new object();
        private bool _killThread = false;
        public WorkerThread(string name, int interval)
        {
            _name = name;
            _interval = interval * 1000;
            _job = new ThreadStart(LoadData);
            _thread = new Thread(_job);
            //Console.WriteLine("WorkerThread constructor: thread " + _thread.ManagedThreadId + " created. Called from thread " + Thread.CurrentThread.ManagedThreadId);
            _thread.Start();
        }
        //Loads the data. Called from separate thread. Lasts 0.5 seconds.
        //
        //private void LoadData(object state)
        private void LoadData()
        {
            while (true)
            {
                //check to see if thread it to be stopped.
                bool isKilled = false;
                lock (_syncObject)
                {
                    isKilled = _killThread;
                }
                if (isKilled)
                    return;
                for (int i = 0; i < 10; i++)
                {
                    //Console.WriteLine(string.Format("Worker thread {0} ({2}): {1}", _name, i, Thread.CurrentThread.ManagedThreadId));
                    Thread.Sleep(50);
                }
                Thread.Sleep(_interval);
            }
        }
        public void Stop()
        {
            //Console.WriteLine("Stop: thread " + _thread.ManagedThreadId + " called from thread " + Thread.CurrentThread.ManagedThreadId);
            //_thread.Abort();
            lock (_syncObject)
            {
                _killThread = true;
            }
            _thread.Join();
        }
        #region IDisposable Members
        public void Dispose()
        {
            //Console.WriteLine("Dispose: thread " + _thread.ManagedThreadId + " called from thread " + Thread.CurrentThread.ManagedThreadId);
            //_thread.Abort();
            lock (_syncObject)
            {
                _killThread = true;
            }
            _thread.Join();
        }
        #endregion
    }
