    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var allEntities = modelBuilder.Model.GetEntityTypes();
    
        foreach (var entity in allEntities)
        {
            entity.AddProperty("CreatedDate",typeof(DateTime));
            entity.AddProperty("UpdatedDate",typeof(DateTime));
        }
    }
