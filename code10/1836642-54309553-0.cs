    IDisposable disposable;
    try
    {
      disposable = GetLock();
      // rest of using block
    }
    finally
    {
      if (disposable != null)
        disposable.Dispose();
    }
    
