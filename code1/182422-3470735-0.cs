    System.Threading.ThreadPool.QueueNewWorkerItem(new System.Threading.WaitCallback(StartProcess));
    
    void StartProcess(object state)
    {
        Process.Start(...);
    }
