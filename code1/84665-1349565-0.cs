    System.Diagnostics.Process proc = new System.Diagnostics.Process();
    proc.EnableRaisingEvents=false; 
    proc.StartInfo.FileName = "xdg-open"; //best guess
    proc.StartInfo.Arguments = string_url;
    proc.Start();
    proc.WaitForExit();
