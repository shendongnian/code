    Process[] processes = Process.GetProcesses();
    string thisProcess = Process.GetCurrentProcess().MainModule.FileName;
    string thisProcessName = Process.GetCurrentProcess().ProcessName;
    foreach (Process process in processes)
    {
       // Compare process name, this will weed out most processes
       if (thisProcessName.CompareTo(process.ProcessName) != 0) continue;
       // Check the file name of the processes main module
       if (thisProcess.CompareTo(process.MainModule.FileName) != 0) continue;
       if (Process.GetCurrentProcess().Id == process.Id) 
       {
         // We don't want to commit suicide
         continue;
       }
       // Tell the other instance to die
       Win32.SendMessage(process.MainWindowHandle, Win32.WM_CLOSE, 0, 0);
    }
