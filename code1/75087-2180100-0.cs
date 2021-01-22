    public static void BulkDispose(object[] objects)
    {
      foreach (object o in objects)
      {
        if (o != null)
        {
          if (o is IDisposable)
          {
            IDisposable disposable = o as IDisposable;
            disposable.Dispose();
          }
        }
      }
    }
