    public void UpdateServerData()
    {
        for (int i = 0; i < NumThreads ; i++)
        {
            resetEvents[i] = new ManualResetEvent(false);
            ThreadPool.QueueUserWorkItem(new WaitCallback(DoWork), resetEvents[i]);
        }
        WaitHandle.WaitAll(resetEvents);
    }
    private void DoWork(object param)
    {
        //do some random work
        (param as ManualResetEvent).Set();
    }
