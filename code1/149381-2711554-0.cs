    var procList = Process.GetProcesses().Where(process => process.ProcessName.Contains("notepad"));
    foreach (var process in procList)
    {
        Console.WriteLine("Path to {0}: {1}", process.ProcessName, Path.GetDirectoryName(process.MainModule.FileName));
    }
