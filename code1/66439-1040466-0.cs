    List<int> idList = new List<int>();
    
    foreach(ProcessStartTimePair proc in knownProcesses)
    {
        idList.Add(proc.Process.Id);
    }
    
    if(idList.Contains(p.Id))
    {
        // ...
    }
