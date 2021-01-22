    public void DoStuff()
    {
        lock(this.SyncRoot)
        {
            InternalDoStuff();
        }
    }
    
    protected virtual void InternalDoStuff()
    {
        // do stuff
    }
