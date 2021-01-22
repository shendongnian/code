    private Process GetProc(string workingDirectory)
        {
            return new Process
                       {
                           StartInfo = new ProcessStartInfo
                                           {
                                               WorkingDirectory = workingDirectory,
                                               UseShellExecute = false,
                                               RedirectStandardOutput = true,
                                               FileName = "YOUR_EXECUTABLE"
                                           }
                       };
        }
