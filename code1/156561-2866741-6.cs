    private void Delay(Action action, int ms)
    {
        if (ms <= 0)
        {
            action();
            return;
        }
    
        System.Threading.WaitCallback delayed = state =>
        {
            System.Threading.Thread.Sleep(ms);
            action();
        };
    
        System.Threading.ThreadPool.QueueUserWorkItem(delayed);
    }
