    public void EnumerateInLock(Action<IEnumerable<T>> action)
    {
        var e = new EnumeratorImpl(this);
        try
        {
            _lock.EnterReadLock();
            action(e);
        }
        finally
        {
            e.Dispose();
            _lock.ExitReadLock();
        }
    }
