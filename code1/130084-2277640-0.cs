    Semaphore smphSync = new Semaphore(0, 5);
    Queue<IResource> resources;
    private _lockObj = new object();
    private IResource GetResource()
    {
        smphSync.WaitOne();
        lock( _lockObj ) 
        {
            IResource res = resources.Dequeue();
            return res;
        }
    }
    private ReleaseResource(IResource res)
    {
        lock( _lockObj )
        {
            resources.Enqueue(res);
        }
        smphSync.Release();
    }
