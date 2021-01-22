    var previousProcesses = Process
       .GetProcessesByName("Matlab")
       .Select(a => a.Id)
       .ToArray();
    var process = Process.Start(startInfo);
    process.WaitForExit();
    var newProcessRunning = Process
       .GetProcessesByName("Matlab")
       .Where(a => !previousProcesses.Contains(a.Id));
    if (newProcessRunning.Count() != 0)
       newProcessRunning.First().WaitForExit();
