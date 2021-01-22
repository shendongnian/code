    ...
        
    using System.Diagnostics;
    
    ...
    
    ProcessStartInfo p1 = new ProcessStartInfo();
      p1.FileName = "runas";
      p1.Arguments = String.Format("/env /u:{0} cmd", user);
    Process.Start(p1);
    
    ...
    
