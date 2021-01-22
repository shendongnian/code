    List<string> myprocs; // populated with process names
    Process[] Procs = Process.GetProcesses();
    foreach(Process proc in Procs)
    {
      if(myprocs.Contains(proc.ProcessName))
      {
         myprocs.Remove(proc.ProcessName);
      }
    }
    // whatever that is left over in myprocs at this point is your remainder process names.
