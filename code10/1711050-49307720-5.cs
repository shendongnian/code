    _lock.EnterReadLock();
    try
    {
        // safe iteration
        foreach (MyDoggie item in DoggieList)
            ...
    }
    finally
    {
        _lock.ExitReadLock();
    }    
