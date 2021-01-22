    public static void Monitor()
        { 
            ArrayList existingProcesses = GetExistingProcess();  
            while (true)
            {  
                ArrayList currentProcesses = new ArrayList();
                currentProcesses = GetCurrentProcess();
 
                ArrayList NewApps = new ArrayList(GetCurrentProcess());
                foreach (var p in ExistingProcess)
                {
                    NewApps.Remove(p); 
                }
                string str = "";
                foreach (string NewApp in NewApps)
                {
                    str = "Process Name : " + NewApp + "   Process ID : " + System.Diagnostics.Process.GetProcessesByName(NewApp)[0].Id.ToString() + " ";
                }
                MessageBox.Show(str);
            }
        }
