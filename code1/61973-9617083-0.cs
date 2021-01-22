     public Process IsProcessOpen(string name)
            {
                foreach (Process clsProcess in Process.GetProcesses())
                    if (clsProcess.ProcessName.Contains(name))
                        return clsProcess;
                return null;
            }
