    private ReaderWriterLock myLock = new ReaderWriterLock();
    
    public void SaveToDisk()
    {
         myLock.AcquireWriterLock();
         try
         {
              ... write code ...
         } 
         finally
         {
              myLock.ReleaseWriterLock();
         }
    }
    
    public void ReadFromDisk()
    {
         myLock.AcquireReaderLock();
         try
         {
              ... read code ...
         } 
         finally
         {
              myLock.ReleaseReaderLock();
         }
    }
