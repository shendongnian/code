    if (Monitor.TryEnter(lockObj, 0)) {
        // got the lock !
        try {
            // code
        }
        finally { // release the lock
            Monitor.Exit(lockObj);
        }
    }
