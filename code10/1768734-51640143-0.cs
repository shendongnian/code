    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Foo>()
            .Property(p => p.RegistrationId)
            .HasComputedColumnSql([SQL HERE]);
    }
