    private readonly ManualResetEvent _ExitThreadsEvent = new ManualResetEvent(false);
    private Thread _MyThread;
    public void Stop()
    {
        _ExitThreadsEvent.Set();
        if (_MyThread != null)
        {
            if (!_MyThread.Join(5000))
            {
                _MyThread.Abort();
            }
            _MyThread = null;
        }
    }
    private void MyThread()
    {
        if (!_ExitThreadsEvent.WaitOne(1))
        {
            // Do some work...
        }
        if (!_ExitThreadsEvent.WaitOne(1))
        {
            // Do some more work...
        }
    }
