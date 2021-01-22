    ...
    using System.Diagnostics;
    ...
    var startInfo = new ProcessStartInfo();
    
      startInfo.WorkingDirectory = // working directory
      // set additional properties 
    
    Process proc = Process.Start(startInfo);
