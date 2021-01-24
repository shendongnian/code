    private ReaderWriterLockSlim lock = new ReaderWriterLockSlim();
    public string Read () {
        lock.EnterReadLock ();
        try {
            return "xxx";
        } finally {
            lock.ExitReadLock();
        }
    }
    public void Write () {
        lock.EnterWriteLock ();
        try {
            // ...
        } finally {
            lock.ExiteWriteLock ();
        }
    }
