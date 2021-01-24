    using System.Diagnostics;
    Process process = new Process();
    ProcessStartInfo procInfo = new ProcessStartInfo()
    {
        FileName = @"C:\Program Files\Notepad++\notepad++.exe",
        Arguments = Path.Combine(Application.StartupPath, "[Some File].txt"),
    };
    process.StartInfo = procInfo;
    process.Start();
    if (process != null) process.Dispose();
