    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.EntitiesOfType<ISoftDeletable>(builder =>
        {
            builder.Property<bool>(nameof(ISoftDeletable.IsActive)).HasDefaultValue(true);
        });
    }
