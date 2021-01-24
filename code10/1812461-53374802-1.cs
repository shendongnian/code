    var pass = new SecureString();
    pass.AppendChar('p');
    pass.AppendChar('a');
    pass.AppendChar('s');
    pass.AppendChar('s');
    
    Process p = new Process();
    ProcessStartInfo startInfo = new ProcessStartInfo("CMD");
    startInfo.Verb = "runas";
    
    startInfo.Arguments = "/user:Administrator \"cmd /C  C:\\info.bat\"";
    startInfo.Password = pass;
    startInfo.UseShellExecute = false;
    startInfo.RedirectStandardOutput = true;   
    p.StartInfo = startInfo;
    
    p.Start();
    
    string output = p.StandardOutput.ReadToEnd();
    p.WaitForExit();
