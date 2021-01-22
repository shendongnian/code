    ReaderWriterLockSlim sync = new ReaderWriterLockSlim();
    IDisposable d = sync.Read();
    try
    {
      // Do stuff
    }
    finally
    {
      d.Dispose();
    }
