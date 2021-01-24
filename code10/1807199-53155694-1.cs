    public MyObjectContext(string connectionString)
                     : base(connectionString)
    {
         ContextOptions.LazyLoadingEnabled = true;
    }
