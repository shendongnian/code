    Process thisProcess = Process.GetCurrentProcess();
            Process[] allProcesses = Process.GetProcessesByName(thisProcess.ProcessName);
            Process otherProcess = null;
            foreach (Process p in allProcesses )
            {
                if ((p.Id != thisProcess.Id) && (p.MainModule.FileName == thisProcess.MainModule.FileName))
                {
                    otherProcess = p;
                    break;
                }
            }
                
           if (otherProcess != null)
           {
               //note IntPtr expected by API calls.
               IntPtr hWnd = otherProcess.MainWindowHandle;
               //restore if minimized
               ShowWindow(hWnd ,1);
               //bring to the front
               SetForegroundWindow (hWnd);
           }
            else
            {
                //run your app here
            }
