    public static readonly Synchronizer<int> sPostSync = new Synchronizer<int>();
    ....
    using(var theLock = sPostSync.Lock(myID))
    lock (theLock)
    {
        ...
    }
