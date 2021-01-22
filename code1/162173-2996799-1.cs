    public static int ExecuteCommand(string Command, int Timeout)
    {
        int exitCode;
        var processInfo = new ProcessStartInfo("cmd.exe", "/C " + Command);
        processInfo.CreateNoWindow = true;
        processInfo.UseShellExecute = false;
        Process process = Process.Start(processInfo);
        process.WaitForExit(Timeout);
        exitCode = process.ExitCode;
        process.Close();
        return exitCode;
    }
