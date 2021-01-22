            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "xxxxxxxxxxxx.exe";
            info.Arguments = "yyyyyyyyyy";
            info.UseShellExecute = true;
            info.CreateNoWindow = true;
            info.WindowStyle = ProcessWindowStyle.Maximized;
            info.RedirectStandardInput = false;
            info.RedirectStandardOutput = false;
            info.RedirectStandardError = false;
            System.Diagnostics.Process p = System.Diagnostics.Process.Start(info); 
            p.WaitForInputIdle();
            Thread.Sleep(3000);
            Process[] p1 ;
        if(p.MainWindowHandle == null)
        {
            List<String> arrString = new List<String>();
            foreach (Process p1 in Process.GetProcesses())
            {
                // Console.WriteLine(p1.MainWindowHandle);
                arrString.Add(Convert.ToString(p1.ProcessName));
            }
            p1 = Process.GetProcessesByName("xxxxxxxxxxxx");
            //p.WaitForInputIdle();
            Thread.Sleep(5000);
          SetParent(p1[0].MainWindowHandle, this.panel2.Handle);
        }
        else
        {
         SetParent(p.MainWindowHandle, this.panel2.Handle);
         }
        
