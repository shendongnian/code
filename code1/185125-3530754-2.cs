    public static void Restart()
    {
        // ...
        ExitInternal();            // Causes the application to exit.
        Process.Start(startInfo);  // Starts a new process.
        // ...
    }
