 TempLog.Clear();   // initial "new" list
 foreach (CLogger ready in PlayerLog)
 {
      if (ready.UpdateReady != true)
           TempLog.Add(ready); // item being kept (not removed) - add to "new" list
 }
              
 if (TempLog.Count != PlayerLog.Count)  // check if any items were not kept
 {
      PlayerLog.Clear();
      PlayerLog.AddRange(TempLog);
      new Thread(Update).Start();  // Run update code 
 }
