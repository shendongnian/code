    // initially set to a "non-signaled" state, ie will block
    // if inspected
    private readonly AutoResetEvent _isStopping = new AutoResetEvent (false);
    public void Process()
    {
        TimeSpan waitInterval = TimeSpan.FromMilliseconds (2000);
        // will block for 'waitInterval', unless another thread,
        // say a thread requesting termination, wakes you up. if
        // no one signals you, WaitOne returns false, otherwise
        // if someone signals WaitOne returns true
        for (; !_isStopping.WaitOne (waitInterval); )
        {
            // do your thang!
        }
    }
