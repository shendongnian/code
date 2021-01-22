    using System.Diagnostics;
    Process[] processes = Process.GetProcessesByName("notepad");
    foreach (Process p in processes)
    {
        p.CloseMainWindow();
    }
