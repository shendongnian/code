    Process proc = new Process
                   {
                       StartInfo =
                           {
                               RedirectStandardError = true,
                               RedirectStandardOutput = true,
                               UseShellExecute = false,
                           }
                   };
    proc.Start();
    string errorMessage = proc.StandardError.ReadToEnd();
    proc.WaitForExit();
    string outputMessage = proc.StandardOutput.ReadToEnd();
    proc.WaitForExit();
