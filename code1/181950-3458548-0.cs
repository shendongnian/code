    // declare an object to use for locking
    Object lockObj = new Object();
    public void SomeMethod()
    {    
        lock (lockObj )
        {
            // Critical code section
        }
    }
