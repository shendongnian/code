    for (int i = PlayerLog.Count - 1; i >= 0; i--)
    {
          var ready = PlayerLog[i];
          if (ready.UpdateReady)
          {
               TempLog.Add(ready);
               PlayerLog.RemoveAt(i);
          }
    }
