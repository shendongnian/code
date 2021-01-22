    public static void CheckForMainThread()
    {
        if (Thread.CurrentThread.GetApartmentState() == ApartmentState.STA &&
            !Thread.CurrentThread.IsBackground && !Thread.CurrentThread.IsThreadPoolThread && Thread.CurrentThread.IsAlive)
        {
            MethodInfo correctEntryMethod = Assembly.GetEntryAssembly().EntryPoint;
            StackTrace trace = new StackTrace();
            StackFrame[] frames = trace.GetFrames();
            for (int i = frames.Length - 1; i >= 0; i--)
            {
                MethodBase method = frames[i].GetMethod();
                if (correctEntryMethod == method)
                {
                    return;
                }
            }
        }
    
        // throw exception, the current thread is not the main thread...
    }
