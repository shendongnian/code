    ReaderWriterLockSlim cacheLock = new ReaderWriterLockSlim();
    Hashtable myTable = new Hashtable();
    Parallel.ForEach(items, (item, loopState) =>
    {
        cacheLock.EnterReadLock();
        MyObject myObj = myTable.TryGet(item.Key);
        cacheLock.ExitReadLock();
        
        // If the object isn't cached, calculate it and cache it
        if(myObj == null)
        {
           myObj = SomeIntensiveOperation();
           cacheLock.EnterWriteLock();
           try
           {
               myTable.Add(item.Key, myObj);
           }
           finally
           {
               cacheLock.ExitWriteLock();
           }           
        }
        // Do something with myObj
        // some code here
    }
    
    static object TryGet(this Hashtable table, object key)
    {
        if(table.Contains(key))
            return table[key]
        else
            return null;
    }
