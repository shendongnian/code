    {
      SomeType t;
      try
      {
        t = new SomeType();
        t.Something();
      }
      finally
      {
        t.Dispose();
      }
    }
