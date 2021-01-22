    void timerFunction(object data)
    {
      lock (tMap.SyncRoot)
      {
        List<UInt32> toRemove = new List<UInt32>();
        foreach (UInt32 id in tMap.Keys)
        {
          MyObj obj=(MyObj) runScriptMap[id];
          obj.time = obj.time -1;
          if (obj.time <= 0)
          {                      
            toRemove.Add(id);
          }
        }
        foreach (UInt32 id in toRemove)
        {
          tMap.Remove(id);
        }
      }
    }
