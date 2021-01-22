    protected override void ProcessRecord()
    {
      // Get the current processes
      Process[] processes = Process.GetProcesses();
     
      // Write the processes to the pipeline making them available
      // to the next cmdlet. The second parameter of this call tells 
      // PowerShell to enumerate the array, and send one process at a 
      // time to the pipeline.
      WriteObject(processes, true);
    }
