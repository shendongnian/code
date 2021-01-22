      try
      {
        throw new T();
      }
      catch (Exception dbgEx)
      {
        T ex = dbgEx as T;
        if (ex != null)
        {
          Console.WriteLine(ex.Message);
        }
      }
