    private readonly object balanceLock = new object();
    
    public void StartShellProcessAsync ()
    {
        ShellThread = new Thread(() =>
        {
            lock(balanceLock)
            {
    
            ShellProcess = new Process();
            ShellProcess.StartInfo.FileName = "adb.exe";
            ShellProcess.StartInfo.Arguments = "shell";
    
            ShellProcess.StartInfo.CreateNoWindow = false;
            ShellProcess.StartInfo.UseShellExecute = false;
    
            ShellProcess.StartInfo.RedirectStandardOutput = true;
            ShellProcess.StartInfo.RedirectStandardError = true;
            ShellProcess.StartInfo.RedirectStandardInput = true;
    
            ShellProcess.EnableRaisingEvents = true;
            ShellProcess.OutputDataReceived += new DataReceivedEventHandler(OnOutputDataReceived);
            ShellProcess.ErrorDataReceived += new DataReceivedEventHandler(OnErrorDataReceived);
    
            ShellProcess.Exited += new EventHandler(OnProcessExited);
    
            ShellProcess.Start();
            ShellProcess.BeginOutputReadLine();
            ShellProcess.BeginErrorReadLine();
            ShellProcess.WaitForExit();
    
           }
       });
       ShellThread.Start();
    }
