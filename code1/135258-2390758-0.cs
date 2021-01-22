    void timerFunction(object data)
        {
        lock (tMap.SyncRoot)
        {
          IList<UInt32> toDelete = new List<UInt32>();
          foreach (UInt32 id in tMap.Keys)
          {
             
             MyObj obj=(MyObj) runScriptMap[id];
             obj.time = obj.time -1;
             if (obj.time <= 0)
             {                      
                toDelete.add(id);
             }
           }
          foreach(UInt32 i in toDelete)
          {
              tMap.Remove(i);
          }
        }
