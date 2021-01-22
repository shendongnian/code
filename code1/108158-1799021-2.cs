    private readonly object dictionaryLock = new object();
    private readonly object creationLocksLock = new object();
    private readonly Dictionary<string, Thingey> thingeys;
    private readonly Dictionary<string, object> creationLocks;
    public Thingey GetThingey(Request request)
    {
        string key = request.ThingeyName;
        Thingey ret;
        bool entryExists;
        lock (dictionaryLock)
        {
           entryExists = thingeys.TryGetValue(key, out ret);
           // Atomically mark the dictionary to say we're creating this item,
           // and also set an entry for others to lock on
           if (!entryExists)
           {
               thingeys[key] = null;
               lock (creationLocksLock)
               {
                   creationLocks[key] = new object();          
               }
           }
        }
        // If we found something, great!
        if (ret != null)
        {
            return ret;
        }
        // Otherwise, see if we're going to create it or whether we need to wait.
        if (entryExists)
        {
            object creationLock;
            lock (creationLocksLock)
            {
                creationLocks.TryGetValue(key, out creationLock);
            }
            // If creationLock is null, it means the creating thread has finished
            // creating it and removed the creation lock, so we don't need to wait.
            if (creationLock != null)
            {
                lock (creationLock)
                {
                    Monitor.Wait(creationLock);
                }
            }
            // We *know* it's in the dictionary now - so just return it.
            lock (dictionaryLock)
            {
               return thingeys[key];
            }
        }
        else // We said we'd create it
        {
            Thingey thingey = new Thingey(request);
            // Put it in the dictionary
            lock (dictionaryLock)
            {
               thingeys[key] = thingey;
            }
            // Tell anyone waiting that they can look now
            lock (creationLocksLock)
            {
                Monitor.PulseAll(creationLocks[key]);
                creationLocks.Remove(key);
            }
            return thingey;
        }
    }
