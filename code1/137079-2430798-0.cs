    static void Main(string[] args)
    {
        for (int i=0; i<10; i++)
            System.Threading.ThreadPool.QueueUserWorkItem(new WaitCallback(DbWork));
    }
    
    public void DbWork(object state)
    {
        // Call your database code here.
    }
