    ProcessStartInfo startInfo = new ProcessStartInfo();
    startInfo.UseShellExecute = true;
    startInfo.WorkingDirectory = Environment.CurrentDirectory;
    startInfo.FileName = Application.ExecutablePath;
    startInfo.Arguments = "-doSomethingThatRequiresElevationAndExit";
    startInfo.Verb = "runas";
    try
    {
        Process p = Process.Start(startInfo);
        p.WaitForExit();
    }
    catch(System.ComponentModel.Win32Exception ex)
    {
        return;
    }
