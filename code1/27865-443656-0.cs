    private static readonly object syncLock = new object();
    public void SaveToDisk()
    {
         lock(syncLock)
         {
              ... write code ...
         }
    }
    public void ReadFromDisk()
    {
         lock(syncLock)
         {
              ... read code ...
         }
    }
