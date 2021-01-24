    ManagedObject obj = new ManagedObject();
    try
    {
      int usualNumber = 0;
      // some magic stuff
      ...
      // magic stuff ends
      return usualNumber;
    }
    finally
    {
      if (obj != null)
        ((IDisposable)obj ).Dispose();
    }
