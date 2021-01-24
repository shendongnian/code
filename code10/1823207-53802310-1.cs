    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CompanyEntityTypeConfiguraton());
    
        base.OnModelCreating(modelBuilder);
    
        modelBuilder.RemovePluralizingTableNameConvention();
        modelBuilder.OnDeleteCascading();
    }
