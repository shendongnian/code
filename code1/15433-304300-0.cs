    private void elevateCurrentProcess()
    {
        ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.UseShellExecute = true;
        startInfo.WorkingDirectory = Environment.CurrentDirectory;       
        startInfo.FileName = Application.ExecutablePath;
        startInfo.Verb = "runas";
    
        try
        {
            Process p = Process.Start(startInfo);
        }
        catch
        {
            // User didn't allow UAC
            return;
        }
        Application.Exit();
    }
