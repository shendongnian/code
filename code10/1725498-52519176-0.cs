    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    modelBuilder.Entity<someobject>(builder =>
    {
        builder.Property(i => i.CreatedAt).Metadata.AfterSaveBehavior = PropertySaveBehavior.Ignore;
    });
    
