    private class Payload
    {
        public File File;
        public AutoResetEvent Handle;
    }
    private void ProcessFile(Object data)
    { 
        Payload p = (Payload)data;
    
        foreach(Operation oprn in getOperationsForFile(p.File))
        {
            performOperation(f, oprn);
        }
        p.Handle.Set();
    }
    ...
    WaitHandle[] handles = new WaitHandle[queue.Count];
    int index = 0;
    
    while(queue.Count > 0)
    {        
        handles[index] = new AutoResetEvent();
        Payload p = new Payload();
        p.File = queue.Dequeue();
        p.Handle = handles[index];
        ThreadPool.QueueUserWorkItem(new WaitCallback(ProcessFile), p);
        index++;
    }
    WaitHandle.WaitAll(handles);
