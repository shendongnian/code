    public static void main(string[] args)
    {
       Process p = new Process("MyApp");
       ProcessStartUpInfo pinfo = new ProcessStartUpInfo();
       p.StartupInfo = pinfo;
       pinfo.CreateNoWindow = true;
       pinfo.ShellExecute = false;
       
       p.RaiseEvents = true;
    
       AutoResetEvent wait = new AutoResetEvent(false);
       p.ProcessExit += (s,e)=>{ wait.Set(); };
       
       p.Start();
       wait.WaitOne();
    }
