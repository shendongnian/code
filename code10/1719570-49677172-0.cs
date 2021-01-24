    static void ConfigureDBEntity<TEntity>(ModelBuilder modelBuilder)
    	where TEntity : DBEntity
    {
    	var entity = modelBuilder.Entity<TEntity>();
    
    	entity
    		.Property(e => e.CreatedOn)
    		.HasDefaultValueSql("GETDATE()");
    
    	entity
    		.Property(e => e.UpdatedOn)
    		.HasComputedColumnSql("GETDATE()");
    
    	entity
    		.Property(e => e.EntityStatus)
    		.HasDefaultValue(EntityStatus.Created);
    
    }
