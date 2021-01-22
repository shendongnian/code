    ProcessStartInfo info = new ProcessStartInfo(...)
    info.UseShellExecute = false;
    info.RedirectStandardOutput = true;
    info.RedirectStandardError = true;
    
    Process p = Process.Start(info);
    p.OutputDataReceived += p_OutputDataReceived;
    p.ErrorDataReceived += p_ErrorDataReceived;
    
    p.BeginOutputReadLine();
    p.BeginErrorReadLine();
    p.WaitForExit();
..
    void p_OutputDataReceived(object sender, DataReceivedEventArgs e)
    {
      Console.WriteLine("Received from standard out: " + e.Data);
    }
    void p_ErrorDataReceived(object sender, DataReceivedEventArgs e)
    {
      Console.WriteLine("Received from standard error: " + e.Data);
    }
