    class ExceptionLogger
    {
      Exception _ex;
      public ExceptionLogger(Exception ex)
      {
        _ex = ex;
      }
      public void DoLog()
      {
        Console.WriteLine(_ex.ToString()); //Will display en-US message
      }
    }
