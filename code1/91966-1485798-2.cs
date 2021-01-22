    public static class SynchronizeInvokeUtil
    {
        public static void SafeInvoke(this ISynchroniseInvoke sync, Action action)
        {
            if (sync.InvokeRequired)
                sync.Invoke(action);
            else
                action();
        }
        public static void SafeBeginInvoke(this ISynchroniseInvoke sync, 
                                           Action action)
        {
            if (sync.InvokeRequired)
                sync.BeginInvoke(action);
            else
                action();
        }
    }
