        private bool KillProcess(string name)
        {
            foreach (Process clsProcess in Process.GetProcesses())
            {
                if (clsProcess.ProcessName.ToLower().StartsWith(name.ToLower()))
                {
                    clsProcess.Kill();
                    return true;
                }
            }
           return false;
        }
