        string[] files = Directory.GetFiles(target_dir);
        List<Process> lstProcs = new List<Process>();
        foreach (string file in files)
        {
            lstProcs = ProcessHandler.WhoIsLocking(file);
            if (lstProcs.Count > 0) // deal with the file lock
            {
                foreach (Process p in lstProcs)
                {
                    if (p.MachineName == ".")
                        ProcessHandler.localProcessKill(p.ProcessName);
                    else
                        ProcessHandler.remoteProcessKill(p.MachineName, txtUserName.Text, txtPassword.Password, p.ProcessName);
                }
                File.Delete(file);
            }
            else
                File.Delete(file);
        }
