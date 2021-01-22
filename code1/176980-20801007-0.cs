    var chromeDriverProcesses = Process.GetProcesses().
                                     Where(pr => pr.ProcessName == "chromedriver");
        
    foreach (var process in chromeDriverProcesses)
    {
         process.Kill();
    }
