    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer(...)
            .ConfigureWarnings(warnings => 
                               warnings.Throw(RelationalEventId.QueryClientEvaluationWarning));
    }
    
