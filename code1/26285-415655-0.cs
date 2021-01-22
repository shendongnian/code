    void RunWithRedirect(string cmdPath)
    {
        var proc = new Process();
        proc.StartInfo.FileName = cmdPath;
    
        // set up output redirection
        proc.StartInfo.RedirectStandardOutput = true;
        proc.StartInfo.RedirectStandardError = true;    
        proc.EnableRaisingEvents = true;
        proc.StartInfo.CreateNoWindow = true;
        // see below for output handler
        proc.ErrorDataReceived += proc_DataReceived;
        proc.OutputDataReceived += proc_DataReceived;
        
        proc.Start();
        
        proc.BeginErrorReadLine();
        proc.BeginOutputReadLine();
    
        proc.WaitForExit();
    }
    
    void proc_DataReceived(object sender, DataReceivedEventArgs e)
    {
        // output will be in string e.Data
    }
