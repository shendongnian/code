    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Students>().Ignore(t =>new {t.CreatedDate, t.CreatedBy, t.CreateRole, t.UpdatedDate, t.Updatedby, t.UpdatedRole});
    
        base.OnModelCreating(modelBuilder);
    }
