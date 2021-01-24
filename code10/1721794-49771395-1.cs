    void Main()
            {
            var psi = new ProcessStartInfo("cmd.exe", "/c notepad");
            var cmdProcess = Process.Start(psi);
            Thread.Sleep(2000);
            KillProcessAndChildren(cmdProcess.Id);
        }
        public void KillProcessAndChildren(int pid)
        {
        using (var searcher = new ManagementObjectSearcher
            ("Select * From Win32_Process Where ParentProcessID=" + pid))
        {
            var moc = searcher.Get();
            foreach (ManagementObject mo in moc)
            {
                KillProcessAndChildren(Convert.ToInt32(mo["ProcessID"]));
            }
            try
            {
                var proc = Process.GetProcessById(pid);
                proc.Kill();
            }
            catch (Exception e)
            {
                // Process already exited.
            }
        }
        }
