    int n = 5;
    for (int i = 0; i < n; i++)
    {
        Thread t = new Thread(MethodToExecute);
        t.Start();
    }
    public void MethodToExecute()
    {
        Process process = new Process();
        // Configure the process using the StartInfo properties.
        process.StartInfo.FileName = "pathToConsoleApp.exe";
        process.Start();
        process.WaitForExit();// Waits here for the process to exit.
    }
