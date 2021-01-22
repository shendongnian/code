    public Boolean TryGetValue(TKey key, out TValue value)
    {
        internalLock.AcquireReaderLock(Timeout.Infine);
        try
        {
            return dictionary.TryGetValue(key, out value);
        }
        finally
        {
            internalLock.ReleaseReaderLock();
        }
    }
