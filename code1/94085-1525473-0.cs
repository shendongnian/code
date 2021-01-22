    using System.Diagnostics;
    foreach (Process proc In Process.GetProcessesByName("iexplorer.exe"))
    {
        // The nice way
        proc.CloseMainWindow();
        // The hard way
        proc.Kill();
    }
