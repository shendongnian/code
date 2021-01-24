    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            modelBuilder.ApplyConfiguration<IHasDisplayId>(typeof(HasDisplayIdEntityTypeConfiguration<>), entityType.ClrType);
        }
    }
