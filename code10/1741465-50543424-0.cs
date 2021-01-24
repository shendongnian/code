    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        // Converts to datetime2 to avoid problems with Server dates and .NET dates conflicts
        modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));
    }
