            Process[] processlist = Process.GetProcesses();
            bool found = false;
            foreach (Process theprocess in processlist)
            {
                if(theprocess.ProcessName == "YourProcessName")
                {
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                return;
            }
