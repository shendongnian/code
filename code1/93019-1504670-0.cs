    private object lockObject = new object();
    
    private void CreateTableIfNotPresent()
    {
        lock(lockObject)
        {
            // check for table presence and create it if necessary, 
            // all inside this block
        }
    }
