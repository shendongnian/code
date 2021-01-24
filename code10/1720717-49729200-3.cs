    private readonly Func<ApplicationDbContext> _appDbContextFactory;
    
    public ResourcesHandler(Func<ApplicationDbContext> appDbContextFactory)
    {
        _appDbContextFactory = appDbContextFactory;
    }
