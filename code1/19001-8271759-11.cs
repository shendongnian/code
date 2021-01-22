    public static int ExecuteCommand(string command, int timeout)
        {
            var processInfo = new ProcessStartInfo("cmd.exe", "/C " + command)
                                  {
                                      CreateNoWindow = true, 
                                      UseShellExecute = false, 
                                      WorkingDirectory = "C:\\",
                                  };
            var process = Process.Start(processInfo);
            process.WaitForExit(timeout);
            var exitCode = process.ExitCode;
            process.Close();
            return exitCode;
        } 
