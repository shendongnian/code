      Assembly assembly  = Assembly.LoadFile(@"C:\dyn.dll");
      Type     type      = assembly.GetType("TestRunner");
      IRunnable runnable = (IRunnable)Activator.CreateInstance(type);
      if (runnable == null) throw new Exception("broke");
      runnable.Run();
