    private readonly YourDbContext _ctx;
    
    public YourService(IDbContextProvider<YourDbContext> dbContextProvider)
    {
        _ctx = dbContextProvider.GetDbContext();
    }
