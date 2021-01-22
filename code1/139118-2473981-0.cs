    public class BackgroundWorkerReplaceable : IDisposable
    {
    
    BackgroupWorker activeWorker = null;
    object activeWorkerSyncRoot = new object();
    List<BackgroupWorker> workerPool = new List<BackgroupWorker>();
    DoWorkEventHandler doWork;
    RunWorkerCompletedEventHandler runWorkerCompleted;
    public bool IsBusy
    {
        get { return activeWorker != null ? activeWorker.IsBusy; : false }
    }
    public BackgroundWorkerReplaceable(DoWorkEventHandler doWork, RunWorkerCompletedEventHandler runWorkerCompleted)
    {
        this.doWork = doWork;
        this.runWorkerCompleted = runWorkerCompleted;
        ResetActiveWorker();
    }
    public void RunOrReplace(Object param, ...) // Overloads could include ProgressChangedEventHandler and other stuff
    {
        try
        {
            lock(activeWorkerSyncRoot)
            {
                if(activeWorker.IsBusy)
                {
                    ResetActiveWorker();
                }
                
                // This works because if IsBusy was false above, there is no way for it to become true without another thread obtaining a lock
                if(!activeWorker.IsBusy)
                {
                    // Optionally handle ProgressChangedEventHandler and other features (under the lock!)
                    
                    // Work on this new param
                    activeWorker.RunWorkerAsync(param);
                }
                else
                { // This should never happen since we create new workers when there's none available!
                    throw new LogicException(...); // assert or similar
                }
            }
        }
        catch(...) // InvalidOperationException and Exception
        { // In my experience, it's safe to just show the user an error and ignore these, but that's going to depend on what you use this for and where you want the exception handling to be
        }
    }
    public void Cancel()
    {
        ResetActiveWorker();
    }
    public void Dispose()
    { // You should implement a proper Dispose/Finalizer pattern
        if(activeWorker != null)
        {
            activeWorker.CancelAsync();
        }
        foreach(BackgroundWorker worker in workerPool)
        {
            worker.CancelAsync();
            worker.Dispose();
            // perhaps use a for loop instead so you can set worker to null?  This might help the GC, but it's probably not needed
        }
    }
    void ResetActiveWorker()
    {
        lock(activeWorkerSyncRoot)
        {
            if(activeWorker == null)
            {
                activeWorker = GetAvailableWorker();
            }
            else if(activeWorker.IsBusy)
            { // Current worker is busy - issue a cancel and set another active worker
                activeWorker.CancelAsync(); // Make sure WorkerSupportsCancellation must be set to true [Link9372]
                // Optionally handle ProgressEventHandler -=
                activeWorker = GetAvailableWorker(); // Ensure that the activeWorker is available
            }
            //else - do nothing, activeWorker is already ready for work!
        }
    }
    BackgroupdWorker GetAvailableWorker()
    {
        // Loop through workerPool and return a worker if IsBusy is false
        // if the loop exits without returning...
        if(activeWorker != null)
        {
            workerPool.Add(activeWorker); // Save the old worker for possible future use
        }
        return GenerateNewWorker();
    }
    BackgroundWorker GenerateNewWorker()
    {
        BackgroundWorker worker = new BackgroundWorker();
        worker.WorkerSupportsCancellation = true; // [Link9372]
        //worker.WorkerReportsProgress
        worker.DoWork += doWork;
        worker.RunWorkerCompleted += runWorkerCompleted;
        // Other stuff
        return worker;
    }
    
    } // class
