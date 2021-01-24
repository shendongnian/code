    private ReaderWriterLockSlim lockObj = new ReaderWriterLockSlim();
    
    private int _ActualValue = 0;
    public int ActualValue
    {
        get
        {
            lockObj.EnterReadLock();
    		
            try
            {
                return _ActualValue;
            }
            finally
            {
                lockObj.ExitReadLock();
            }
        }
        set
        {
            lockObj.EnterWriteLock();
            try
            {
       
                if((value != _ActualValue) && (value < 1000))
                {
                    Log("_ActualValue", value.ToString());
                    _ActualValue = value;
                }
            }
            finally
            {
                lockObj.ExitWriteLock();
            }
        }
    }
