    void MethodTable::DoRunClassInitThrowing()
    {
    
        .
        .
        .
    
        ListLock *_pLock = pDomain->GetClassInitLock();
    
        // Acquire the appdomain lock.
        ListLockHolder pInitLock(_pLock);
    
        .
        .
        .
    
        // Take the lock
        {
            // Get the lock associated with the static constructor or create new a lock if one has not been created yet.
            ListLockEntryHolder pEntry(ListLockEntry::Find(pInitLock, this, description));
    
            ListLockEntryLockHolder pLock(pEntry, FALSE);
    
            // We have a list entry, we can release the global lock now
            pInitLock.Release();
    
            // Acquire the constructor lock.
            // Block if another thread has the lock.
            if (pLock.DeadlockAwareAcquire())
            {
                .
                .
                .
            }
    
            // The constructor lock gets released by calling the destructor of pEntry.
            // The compiler itself emits a call to the destructor at the end of the block
            // since pEntry is an automatic variable.
        }
    
        .
        .
        .
    
    }
