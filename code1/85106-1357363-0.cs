     Assembly runningAssembly = Assembly.GetEntryAssembly();
     if (runningAssembly == null)
     {
        runningAssembly = Assembly.GetExecutingAssembly();
     }
    runningAssembly.GetName().Version;
