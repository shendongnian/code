    public void SpawnSomeThreads(int threads)
    {
        for (int i = 0; i < threads; i++)
        {
            Thread t = new Thread(WorkerThread);
            
            WorkerThreadContext context = new WorkerThreadContext
            {
                // whatever data the thread needs passed into it
            };
            t.Start(context);
        }
    }
    private class WorkerThreadContext
    {
        public string Data { get; set; }
        public int OtherData { get; set; }
    }
    private void WorkerThread(object parameter)
    {
        WorkerThreadContext context = (WorkerThreadContext) parameter;
        // do work here
    }
