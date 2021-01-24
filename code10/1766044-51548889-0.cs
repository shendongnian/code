    services.AddDbContext<dbContext>(options => ...);
    public Repository(dbContext context)
    {
        _context = context;
    }
