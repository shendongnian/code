            // Process already running ? 
            if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1)
            {
                // Show your error message
                MessageBox.Show("xxx is already running.  \r\n\r\nIf the original process is hung up you may need to restart your computer, or kill the current xxx process using the task manager.", "xxx is already running!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                // This process 
                Process currentProcess = Process.GetCurrentProcess();
                // Get all processes running on the local computer.
                Process[] localAll = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);
                // ID of this process... 
                int temp = currentProcess.Id;
                MessageBox.Show("This Process ID:  " + temp.ToString());
                for (int i = 0; i < localAll.Length; i++)
                {
                    // Find the other process 
                    if (localAll[i].Id != currentProcess.Id)
                    {
                        MessageBox.Show("Original Process ID (Switching to):  " + localAll[i].Id.ToString());
                        // Switch to it... 
                        SetForegroundWindow(localAll[i].MainWindowHandle);
                        
                    }
                }
                Application.Current.Shutdown();
                
            }
