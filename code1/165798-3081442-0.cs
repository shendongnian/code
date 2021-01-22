    EventWaitHandle _handle = new EventWaitHandle (false, EventResetMode.ManualReset);
    Object _fileLock = new Object();
     public Logger(string sFile)
    {
    // Do as you do here
    _handle.Set();
    }
    public void Add(string sData)
    {
        _handle.WaitOne ();    // Blocks the thread untill Set() is called on _handle
        Lock(_fileLock){    // Only one thread may enter at a time
           // Do as you do already
        }
    }
  
