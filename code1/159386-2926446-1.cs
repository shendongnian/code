    var ready = PlayerLog.Where(c => c.UpdateReady).ToArray();
    if (ready.Any())
    {
        TempLog.Clear();  //Ensure TempLog is empty
        TempLog.AddRange(ready);
        foreach (CLogger c in ready) PlayerLog.Remove(c);
        new Thread(Update).Start();  // Run update code 
    }       
 
