    private void ProcessFile(File f)
    {     
        foreach(Operation oprn in getOperationsForFile(f))
        {
            performOperation(f, oprn);
        }
        p.Handle.Set();
    }
    private object queueLock = new object();
    private void ThreadProc()
    {
        bool okToContinue = true;
        while(okToContinue)
        {
            File f = null;
            lock(queueLock)
            {
                if(queue.Count > 0) 
                {
                    f = queue.Dequeue();
                }
                else
                {
                    f = null;
                }
            }
            if(f != null)
            {
                ProcessFile(f);
            }
            else
            {
                okToContinue = false;
            }
        }
    }
    ...
    Thread[] threads = new Thread[20]; // arbitrary number, choose the size that works
    for(int i = 0; i < threads.Length; i++)
    {
        threads[i] = new Thread(new ThreadStart(ThreadProc));
  
        thread[i].Start();
    }
    //if you need to wait for them to complete, then use the following loop:
    for(int i = 0; i < threads.Length; i++)
    {
        threads[i].Join();
    }
