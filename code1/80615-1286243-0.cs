    // I mean it! This will cause badness!
    using System.Diagnostics;
    Process me = Process.GetCurrentProcess();
    foreach (Process p in Process.GetProcesses())
    {
        if (P.Id != me.Id)
            P.CloseMainWindow(); // Sends WM_CLOSE; less gentle methods available too
    }
