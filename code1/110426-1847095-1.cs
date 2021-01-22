    Process p = new Process();
    //set all the process start Info...
    p.Start();
    
    someVariableICanGetToLater = p.Id
    
    //Later when you need to kill the process...
    Process pToKill = Process.GetProcessById(someVariableICanGetToLater);
    pToKill.Kill();
