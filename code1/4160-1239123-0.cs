    public static void LogStack()
    {
      var trace = new System.Diagnostics.StackTrace();
      foreach (var frame in trace.GetFrames())
      {
        var method = frame.GetMethod();
        if (method.Name.Equals("LogStack")) continue;
        Log.Debug(string.Format("{0}::{1}", 
            method.ReflectedType != null ? method.ReflectedType.Name : string.Empty,
            method.Name));
      }
    }
