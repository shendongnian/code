    using System.Diagnostics;
       var eProcess = from p in Process.GetProcessesByName("EXCEL")
                       where p.Id == 3700 //whatever Id you have...
                       select p;
        foreach (var process in eProcess)
            process.Kill();
