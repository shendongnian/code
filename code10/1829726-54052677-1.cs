    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.ReplaceService<IDbSetFinder, CustomDbSetFinder>();
        // ...
    }
