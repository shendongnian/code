    static bool RunProc(string exe, string args, string workingDir)
    {
        var prevWorking = Environment.CurrentDirectory;
        try
        {
            Environment.CurrentDirectory = prevWorking;
            Process proc = new Process
            {
                StartInfo =
                {
                   FileName =  exe,
                   CreateNoWindow = true,
                   RedirectStandardInput = true,
                   WindowStyle = ProcessWindowStyle.Hidden,
                   UseShellExecute = false,
                   RedirectStandardError = true,
                   RedirectStandardOutput = true,
                   Arguments = args,
                }
            };
            proc.Start();
            proc.StandardInput.WriteLine(args);
            proc.StandardInput.Flush();
            proc.StandardInput.Close();
            return true;
        }
        finally
        {
            Environment.CurrentDirectory = prevWorking;
        }
    }
