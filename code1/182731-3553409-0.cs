    Subject<Item> toAddObservable;
    ListObservable<Item> buffer;
    void Init()
    {
        // Subjects are an IObservable we can trigger by-hand, they're the 
        // mutable variables of Rx
        toAddObservable = new Subject(Scheduler.TaskPool);
        // ListObservable will hold all our items until someone asks for them
        // It will yield exactly *one* item, but only when toAddObservable
        // is completed.
        buffer = new ListObservable<Item>(toAddObservable);
    }
    void Add(Item to_add)
    {
        lock (this) {
            // Subjects themselves are thread-safe, but we still need the lock
            // to protect against the reset in FetchResults
            ToAddOnAnotherThread.OnNext(to_add);
        }
    }
    IEnumerable<Item> FetchResults()
    {
        IEnumerable<Item> ret = null;
        buffer.Subscribe(x => ret = x);
        lock (this) {
            toAddObservable.OnCompleted();
            Init();     // Recreate everything
        }
        return ret;
    }
