    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        // <... other configurations ...>
        // modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        // modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        // modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        // Configure Decimal to always have a precision of 18 and a scale of 4
        modelBuilder.Conventions.Remove<DecimalPropertyConvention>();
        modelBuilder.Conventions.Add(new DecimalPropertyConvention(18, 4));
        base.OnModelCreating(modelBuilder);
    }
