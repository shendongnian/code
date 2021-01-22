    process.Start();
    while (!process.HasExited)
    {
        // Discard cached information about the process.
        process.Refresh();
        // Just a little check!
        Console.WriteLine("Physical Memory Usage: " + process.WorkingSet64.ToString());
        Thread.Sleep(500);
    }
    foreach (Process current in Process.GetProcessesByName("testprogram"))
    {
        if ((current.Id == process.Id) && !current.HasExited)
            throw new Exception("Oh oh!");
    }
