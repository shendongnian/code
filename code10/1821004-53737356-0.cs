    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (IMutableEntityType mutableEntityType in modelBuilder.Model.GetEntityTypes())
        {
            bool isEntity = mutableEntityType.ClrType.GetInterface($"{nameof(IEntity<int>)}`1") != null;
            if (isEntity)
            {
                modelBuilder.Entity(mutableEntityType.ClrType).Property(nameof(IEntity<int>.Id)).HasColumnName("ID");
            }
        }
    }
