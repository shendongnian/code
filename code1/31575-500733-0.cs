    AutoResetEvent[] waitHandle = new AutoResetEvent[2];
    for(int i = 0; i < 2; i++)
    {
        waitHandle[i] =  new AutoResetEvent(false);
        ThreadPool.QueueUserWorkItem(state =>
        {
            AutoResetEvent handle = state as AutoResetEvent;
            IncrementValue();
            handle.Set();
        }, waitHandle[i]);
    }
    WaitHandle.WaitAll(waitHandle);
    Console.WriteLine("val=" + val + " however it should be " + (10000000 + 10000000));
