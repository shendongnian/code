    using System.Diagnostics;
    
    public void executeCmdCommand(string argument)
    {
        Process process = new System.Diagnostics.Process();
        ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.WindowStyle = ProcessWindowStyle.Hidden;
        startInfo.FileName = "cmd.exe";
        startInfo.Arguments = $"/C {argument}";
        process.StartInfo = startInfo;
    
        process.EnableRaisingEvents = true;
        process.SynchronizingObject = this;
        process.Exited += (sender, e) => {
           // Extracted from old HideImage() function.
           imageControl.Hide();
        };  
        
        process.Start();
        //process.WaitForExit();
    }
