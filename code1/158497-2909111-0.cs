    Process process = Process
        .Start(new ProcessStartInfo("a.exe"){RedirectStandardOutput = true});
    if (process != null)
    {
        process.OutputDataReceived += ((sender, e) =>
                                       {
                                           string consoleLine = e.Data;
                                           //handle data
                                       });
        process.BeginOutputReadLine();
    }
