    private volatile Thread _Thread;
    ...
    if (_Thread == null)
    {
        _Thread = new Thread(new ThreadStart(Some_Work));
        _Thread.Start();
    }
    private void Some_Work()
    {
        try
        {
            // your thread code here
        }
        finally
        {
            _Thread = null;
        }
    }
