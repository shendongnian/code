    ...
        
    using System.Diagnostics;
    
    ...
    
    string UserName = "user name goes here";
    ProcessStartInfo p1 = new ProcessStartInfo();
      p1.FileName = "runas";
      p1.Arguments = String.Format("/env /u:{0} cmd", UserName);
    Process.Start(p1);
    
    ...
    
