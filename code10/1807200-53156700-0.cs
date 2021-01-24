     public MyObjectContext()
            : base(GetConnectionString())
        {
            ContextOptions.LazyLoadingEnabled = true;
        }
