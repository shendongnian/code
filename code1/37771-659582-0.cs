    public abstract class WorkerThreadBase : IDisposable
    {
        private Thread _workerThread;
        protected internal ManualResetEvent _stopping;
        protected internal ManualResetEvent _stopped;
        private bool _disposed;
        private bool _disposing;
        private string _name;
        protected WorkerThreadBase()
            : this(null, ThreadPriority.Normal)
        {
        }
        protected WorkerThreadBase(string name)
            : this(name, ThreadPriority.Normal)
        {
        }
        protected WorkerThreadBase(string name,
            ThreadPriority priority)
            : this(name, priority, false)
        {
        }
        protected WorkerThreadBase(string name,
            ThreadPriority priority,
            bool isBackground)
        {
            _disposing = false;
            _disposed = false;
            _stopping = new ManualResetEvent(false);
            _stopped = new ManualResetEvent(false);
            _name = name == null ? GetType().Name : name; ;
            _workerThread = new Thread(threadProc);
            _workerThread.Name = _name;
            _workerThread.Priority = priority;
            _workerThread.IsBackground = isBackground;
        }
        protected bool StopRequested
        {
            get { return _stopping.WaitOne(1, true); }
        }
        protected bool Disposing
        {
            get { return _disposing; }
        }
        protected bool Disposed
        {
            get { return _disposed; }
        }
        
        public string Name
        {
            get { return _name; }            
        }	
        public void Start()
        {
            ThrowIfDisposedOrDisposing();
            _workerThread.Start();
        }
        public void Stop()
        {
            ThrowIfDisposedOrDisposing();
            _stopping.Set();
            _stopped.WaitOne();
        }
        public void WaitForExit()
        {
            ThrowIfDisposedOrDisposing();            
            _stopped.WaitOne();
        }
        #region IDisposable Members
        public void Dispose()
        {
            dispose(true);
        }
        #endregion
        public static void WaitAll(params WorkerThreadBase[] threads)
        { 
            WaitHandle.WaitAll(
                Array.ConvertAll<WorkerThreadBase, WaitHandle>(
                    threads,
                    delegate(WorkerThreadBase workerThread)
                    { return workerThread._stopped; }));
        }
        public static void WaitAny(params WorkerThreadBase[] threads)
        {
            WaitHandle.WaitAny(
                Array.ConvertAll<WorkerThreadBase, WaitHandle>(
                    threads,
                    delegate(WorkerThreadBase workerThread)
                    { return workerThread._stopped; }));
        }
        protected virtual void Dispose(bool disposing)
        {
            //stop the thread;
            Stop();
            //make sure the thread joins the main thread
            _workerThread.Join(1000);
            //dispose of the waithandles
            DisposeWaitHandle(_stopping);
            DisposeWaitHandle(_stopped);
        }
        protected void ThrowIfDisposedOrDisposing()
        {
            if (_disposing)
            {
                throw new InvalidOperationException(
                    Properties.Resources.ERROR_OBJECT_DISPOSING);
            }
            if (_disposed)
            {
                throw new ObjectDisposedException(
                    GetType().Name,
                    Properties.Resources.ERROR_OBJECT_DISPOSED);
            }
        }
        protected void DisposeWaitHandle(WaitHandle waitHandle)
        {
            if (waitHandle != null)
            {
                waitHandle.Close();
                waitHandle = null;
            }
        }
        protected abstract void Work();
        private void dispose(bool disposing)
        {
            //do nothing if disposed more than once
            if (_disposed)
            {
                return;
            }
            if (disposing)
            {
                _disposing = disposing;
                Dispose(disposing);
                _disposing = false;
                //mark as disposed
                _disposed = true;
            }
        }
        private void threadProc()
        {
            Work();
            _stopped.Set();
        }        
    }
