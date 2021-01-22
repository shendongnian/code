    public class Logger
    {
        // BEST PRACTICE: private synchronization object. 
        // lock on _syncRoot - you should have one for each critical
        // section - to avoid locking on public 'this' instance
        private readonly object _syncRoot = new object ();
        // synchronization device for stopping our log thread.
        // initialized to unsignaled state - when set to signaled
        // we stop!
        private readonly AutoResetEvent _isStopping = 
            new AutoResetEvent (false);
        // use a Queue<>, cleaner and less error prone than
        // manipulating an array. btw, check your indexing
        // on your array queue, while starvation will not
        // occur in your full pass, ordering is not preserved
        private readonly Queue<LogObj> _queue = new Queue<LogObj>();
        ...
        public void Log (string message)
        {
            // you want to lock ONLY when absolutely necessary
            // which in this case is accessing the ONE resource
            // of _queue.
            lock (_syncRoot)
            {
                _queue.Enqueue (new LogObj (DateTime.Now, message));
            }
            // use whatever synchronization device\pattern you like.
            // it is not important that log thread is signaled from
            // 'critical section' above.
            Monitor.Pulse ();
        }
    
        public void GetLog ()
        {
            // while not stopping
            // 
            // if you want _loggerThread to poll for changes,
            // remove your monitor below, and increase WaitOne
            // timeout value to something appropriate
            for (; !_isStopping.WaitOne(1); )
            {
                List<LogObj> logs = null;
                // again lock ONLY when you need to. because our log
                // operations may be time-intensive, we do not want
                // to block pessimistically. what we really want is 
                // to dequeue all available messages and release the
                // shared resource.
                lock (_syncRoot)
                {
                    // copy messages for local scope processing!
                    logs = _queue.ToList ();
                    // clear the queue for new messages
                    _queue.Clear ();
                    // release!
                }
                foreach (LogObj log in logs)
                {
                    // do your thang
                    ...
                }
                // not sure about the monitor bit, similar to
                // _syncRoot, not sure it's good practice to 
                // monitor 'this'. [shrug].
                Monitor.Wait (this);
            }
        }
    }
    ...
    public void Stop ()
    {
        // graceful thread termination. give threads a chance!
        _isStopping.Set ();
        Monitor.Pulse ();
        _loggerThread.Join (100);
        if (_loggerThread.IsAlive)
        {
            _loggerThread.Abort ();
        }
        _loggerThread = null;
    }
