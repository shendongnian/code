    private static void Main(string[] args)
    {
      var parameters = CommandLineUtil.ParseCommandString(args);
    
    #if DEBUG
      RunInDebugMode(parameters);
    #else
      RunInReleaseMode(parameters);
    #endif
    }
    static void RunInDebugMode(IDictionary<string,string> args)
    {
      var counter = new ExceptionCounters();
      SetupDebugParameters(args);
      RunContainer(args, counter, ConsoleLog.Instance);
    }
    
    static void RunInReleaseMode(IDictionary<string,string> args)
    {
      var counter = new ExceptionCounters();
      try
      {
        RunContainer(args, counter, NullLog.Instance);
      }
      catch (Exception ex)
      {
        var exception = new InvalidOperationException("Unhandled exception", ex);
        counter.Add(exception);
        Environment.ExitCode = 1;
      }
      finally
      {
        SaveExceptionLog(parameters, counter);
      }
    }
