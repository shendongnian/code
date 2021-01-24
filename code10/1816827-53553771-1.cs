    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Students>().Ignore(t=>t.CreatedDate).Ignore(t=>t.CreatedBy).Ignore(t=>t.CreateRole).Ignore(t=>t.UpdatedDate).Ignore(t=>t.Updatedby).Ignore(t=>t.UpdatedRole);
    
        base.OnModelCreating(modelBuilder);
    }
