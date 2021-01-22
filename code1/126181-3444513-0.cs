    foreach (EnvDTE.Process p in Dte.Debugger.DebuggedProcesses) {
      if (p.ProcessID == spawnedProcess.Id) {
        // stuff
      }
    }
