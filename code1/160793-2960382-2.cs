    void runProcess(string processName, string args)
    {
        using (Process p = new Process())
        {
            ProcessStartInfo info = new ProcessStartInfo(processName);
            info.Arguments = args;
            info.RedirectStandardInput = true;
            info.RedirectStandardOutput = true;
            info.UseShellExecute = false;
            p.StartInfo = info;
            p.Start();
            string output = p.StandardOutput.ReadToEnd();
            // process output
        }
    }
