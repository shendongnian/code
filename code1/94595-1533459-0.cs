    private void SvnOutputHandler(object sendingProcess,
                                          DataReceivedEventArgs outLine)
    {
        Process p = sendingProcess as Process;
    
        // Save the output lines here
    }
    private void RunSVNCommand()
    {
        ProcessStartInfo psi = new ProcessStartInfo("svn.exe",
                                                    string.Format("update \"{0}\" {1}", parm1, parm2));
    
        psi.UseShellExecute = false;
        psi.CreateNoWindow = true;
    
        // Redirect the standard output of the sort command.  
        // This stream is read asynchronously using an event handler.
        psi.RedirectStandardOutput = true;
        psi.RedirectStandardError = true;
    
        Process p = new Process();
    
        // Set our event handler to asynchronously read the sort output.
        p.OutputDataReceived += SvnOutputHandler;
        p.ErrorDataReceived += SvnOutputHandler;
        p.StartInfo = psi;
    
        p.Start();
    
        p.BeginOutputReadLine();
        p.BeginErrorReadLine();
    
        p.WaitForEnd()
    }
