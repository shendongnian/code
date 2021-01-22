        using System.Diagnostics;
        using System.Threading;
        ProcessStartInfo info = new ProcessStartInfo("myapp.exe", cmd); 
        info.CreateNoWindow = true; 
        info.UseShellExecute = false; 
        info.RedirectStandardError = true; 
        info.RedirectStandardOutput = true; 
        Process p =  new Process();
        p.StartInfo = info; 
        p.BeginOutputReadLine();
        p.BeginErrorReadLine();
        AutoResetEvent wait = new AutoResetEvent(false);
        p.Exited += (s,e)=>{
            wait.Set();
        }
        p.Start();
        wait.WaitOne();
