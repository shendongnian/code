    services.AddDbContext<IdbContext, dbContext>(options => ...);
    public Repository(IdbContext context)
    {
        _context = context;
    }
