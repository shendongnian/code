    public static bool DoWithTimeout<T>(Func<T> func, int timeout, out T result)
    {
        Exception ex = null;
        result = default(T);
        T res = default(T);
        CancellationTokenSource cts = new CancellationTokenSource();
        Task task = Task.Run(() =>
        {
            try
            {
                using (cts.Token.Register(Thread.CurrentThread.Abort))
                {
                    res = func();
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
        if (done)
            result = res;
        else
            cts.Cancel();
        return done;
    }
