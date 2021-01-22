    public static bool DoWithTimeout(Action action, int timeout)
    {
        Exception ex = null;
        CancellationTokenSource cts = new CancellationTokenSource();
        Task task = Task.Run(() =>
        {
            try
            {
                using (cts.Token.Register(Thread.CurrentThread.Abort))
                {
                    action();
                }
            }
            catch (Exception e)
            {
                if (!(e is ThreadAbortException))
                    ex = e;
            }
        }, cts.Token);
        bool done = task.Wait(timeout);
        if (ex != null)
            throw ex;
        if (!done)
            cts.Cancel();
        return done;
    }
