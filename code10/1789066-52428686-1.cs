    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var prop in entity.GetProperties())
            {
                prop.IsConcurrencyToken = true;
            }
        }
        base.OnModelCreating(modelBuilder);
    }
