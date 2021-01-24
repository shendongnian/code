    public MyDbContext(DbContextOptions<MyDbContext> options, bool shouldSeedData = false) :
        base(options)
    {
        ChangeTracker.LazyLoadingEnabled = false; // <--
        _shouldSeedData = shouldSeedData;
    }
