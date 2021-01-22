      Assembly assembly  = Assembly.LoadFile(@"C:\dyn.dll");
      Type     type      = assembly.GetType("TestRunner");
      IRunnable runnable = Activator.CreateInstance(type) as IRunnable;
      if (runnable == null) throw new Exception("broke");
      runnable.Run();
