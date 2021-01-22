    using System.Diagnostics;
    Process [] localAll = Process.GetProcesses();
    foreach(Process p in localAll)
    {
        p.Kill();
    }
