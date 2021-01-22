    public void LogSomething(string msg)
    {
      LogEntry le = new LogEntry { Message = msg };
      le.ExtendedProperties.Add("Called from", new StackFrame(1).GetMethod().ReflectedType);
      Logger.Write(le);
    }
