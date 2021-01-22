    object lockObj = new object();
    public void foo()
    {
        lock(lockObj)
        {
        //do stuff here
        }
    }
