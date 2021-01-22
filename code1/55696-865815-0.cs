    string remoteSystem = "remoteSystemName";
    string procSearch = "notepad";            
    Process[] proc = System.Diagnostics.Process.GetProcessesByName(procSearch, remoteSystem);
    
       if (proc.Length > 0)
    
       {
            Console.WriteLine("Able to find: " + proc[0]);
       }
       else
       {
            Console.WriteLine("Unable to find: " + procSearch);
       }
