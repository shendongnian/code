        // Wrapper method for use with thread pool.
    public void ThreadPoolCallback(Object threadContext)
    {
        System.Data.DataRow r = (System.Data.DataRow)threadContext;
        
        //Do the work
    }
