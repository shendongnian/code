    using System;
    static class Program
    {
      [STAThread]
      static void Main(string[] argv)
      {
        try
        {
          AppDomain.CurrentDomain.UnhandledException += (sender,e)
          => FatalExceptionObject(e.ExceptionObject);
          Application.ThreadException += (sender,e)
          => FatalExceptionHandler.Handle(e.Exception);
          // whatever you need/want here
          Application.Run(new MainWindow());
        }
        catch (Exception huh)
        {
          FatalExceptionHandler.Handle(huh);
        }
      }
      static void FatalExceptionObject(object exceptionObject) {
        var huh = exceptionObject as Exception;
        if (huh == null) {
          huh = new NotSupportedException(
            "Unhandled exception doesn't derive from System.Exception: "
             + exceptionObject.ToString()
          );
        }
        FatalExceptionHandler(huh);
      }
    }
