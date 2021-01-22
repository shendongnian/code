    public static class Runner
    {
        public static void Run(Action action, TimeSpan timeout)
        {
            IAsyncResult ar = action.BeginInvoke(null, null);
            if (ar.AsyncWaitHandle.WaitOne(timeout))
                action.EndInvoke(ar); // This is necesary so that any exceptions thrown by action delegate is rethrown on completion
            else
                throw new TimeoutException("Action failed to complete using the given timeout!");
        }
    }
