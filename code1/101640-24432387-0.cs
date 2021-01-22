    List<ProcEntry> processes = new List<ProcEntry>();
    ProcessEnumerator.Enumerate(ref processes);
    
    foreach (ProcEntry proc in processes)
    {
        if (proc.ExeName == "DataWedge.exe")
        {
            ProcessEnumerator.KillProcess(proc.ID);
        }
    }
