    string processName = "PathTo.exe";
    
    var process = new System.Diagnostics.Process { StartInfo = { FileName = processName  } };
    if (process.Start())
    {
      process.EnableRaisingEvents = true;
      process.Exited += this.Editor_Exited;
    }
    else
    {
     var p = Process.GetProcessesByName(processName);
     p.WaitForExit();
    }
