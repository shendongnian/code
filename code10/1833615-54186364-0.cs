    // ...
    using System.Management.Automation.Runspaces;
    // ...
    // Create an out-of-process runspace...
    using (var runspace = RunspaceFactory.CreateOutOfProcessRunspace(null))
    {
      runspace.Open(); // ... open it ...
      using (PowerShell powerShell = PowerShell.Create())
      {
        powerShell.Runspace = runspace; // ... and assign it to the PowerShell instance.
        // Now setting $env:PATH only takes effect for the separate process
        // in which the runspace is hosted.
        powerShell.Runspace.SessionStateProxy.SetVariable("env:Path",
                    $"{searchTarget}{Path.PathSeparator}{Environment.GetEnvironmentVariable("PATH")}");
        // ...
      }
    }
