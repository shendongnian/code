    while (true)
    {
        var processes = Process.GetProcesses();
        foreach (var process in processes)
        {
            if (process.ProcessName != "SideSync")
                continue;
            Console.WriteLine($"{process.ProcessName}, {process.MainWindowTitle}, {process.MainWindowHandle.ToString()}");
        }
        Thread.Sleep(1000);
    }
