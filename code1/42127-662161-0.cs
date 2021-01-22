    private static object syncRoot = new object();
    public void RunConsolePrint()
    {
        lock(syncRoot)
        {
             RunLockCode("lock");
        }    
    }
