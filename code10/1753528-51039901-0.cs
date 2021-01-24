    private readonly IDbContextProvider<TDbContext> _dbContextProvider;
    
    public YourService(IDbContextProvider<TDbContext> dbContextProvider)
    {
        _dbContextProvider = dbContextProvider;
    }
    public void MethodName(){
        var context = _dbContextProvider.GetDbContext();
        context.YourEntity.OrderBy(a => a.Name);
    }
