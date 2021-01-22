    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Conventions.Remove<DecimalPropertyConvention>();
        modelBuilder.Conventions.Add(new DecimalPropertyConvention(38, 18));
    }
