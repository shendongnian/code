    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Here we identify the Id property to be set to Identity
        // Also, we use change the PropertySaveBehavior on the same
        // property to ignore the values 
        modelBuilder.Entity(modelType)
                    .Property(key.Name)
                    .UseSqlServerIdentityColumn()
                    .Metadata.BeforeSaveBehavior = PropertySaveBehavior.Ignore;
    }
