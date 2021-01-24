    public EfGenericRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<T>();
        _dbContext.Database.Log = Console.Write; 
    }
