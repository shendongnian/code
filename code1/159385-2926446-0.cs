    TempLog.Clear();   //Ensure TempLog is empty
    var ready = PlayerLog.Where(c => c.UpdateReady).ToArray();
    if (ready.Any())
    {
        TempLog.AddRange(ready);
        PlayerLog.RemoveAll(ready);
        new Thread(Update).Start();  // Run update code 
    }       
 
