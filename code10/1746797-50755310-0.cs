    Process A;
        Process B;
        Process C;
        private void findExes()
        {
            List<Process> allProcesses = Process.GetProcesses().ToList().OrderBy(p => p.ProcessName).ToList();
            A = allProcesses.Find(delegate(Process pro) { return pro.ProcessName == "A"; });
            B = allProcesses.Find(delegate(Process pro) { return pro.ProcessName == "B"; });
            C = allProcesses.Find(delegate(Process pro) { return pro.ProcessName == "C"; });
        }
        private void stopAExe_Click(object sender, EventArgs e)
        { 
            findExes();
            if (A != null)
                A.Kill();
            if (  B != null)
            {
                /// RESUME B.EXE 
                /// B.EXE WİLL CONTİNUE 
            }
        }
        private void startAExe_Click(object sender, EventArgs e)
        { 
            findExes();
            if (A == null)
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = @"A.exe";
                Process.Start(startInfo);
                if (B != null)
                {
                    /// 
                    /// DİSABLE B.EXE  ? 
                }
            }
        }
        private void startBExe_Click(object sender, EventArgs e)
        {
            findExes();
         
            if (  B == null)
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = @"B.exe";
                Process.Start(startInfo);
            } 
        }
