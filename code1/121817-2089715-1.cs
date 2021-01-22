    private void firstProcess_OutputDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e)
    {
        if (e.Data == "Starting next process")
        {
            System.Diagnostics.Process newProcess = null;
    
            while (newProcess == null)
            {
                System.Diagnostics.Process[] procs = System.Diagnostics.Process.GetProcesses();
    
                foreach (System.Diagnostics.Process proc in procs)
                {
                    if (proc.ProcessName == "newProcess")
                    {
                        newProcess = proc;
                        break;
                    }
                }
    
                System.Threading.Thread.Sleep(100);
            }
    
            newProcess.OutputDataReceived += new System.Diagnostics.DataReceivedEventHandler(newProcess_OutputDataReceived);
        }
    }
    
    void newProcess_OutputDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e)
    {
        // Do something with your data received here.
    }
