    IEnumerator enumerator = results.GetEnumerator()
    try
    {
      while (enumerator.MoveNext())
      {
        ManagementObject result = (ManagementObject)enumerator.Current;
        IDisposable disposable = (IDisposable)result;
        try
        {
          // Your code goes here.
        }
        finally
        {
          disposable.Dispose();
        }
      }
    }
    finally
    {
      IDisposable disposable = enumerator as IDisposable;
      if (disposable != null)
      {
        disposable.Dispose();
      }
    }
