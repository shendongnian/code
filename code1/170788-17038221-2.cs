    Process[] processes = Process.GetProcessesByName("powerpnt");
    for (int i = 0; i < processes.Count(); i++)
    {
        processes[i].Kill();
    }
