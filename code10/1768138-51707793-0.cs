    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
    	modelBuilder.Types<Entity>().Configure(c =>
    	{
    		c.HasKey(e => e.Id);
    
    		c.Property(e => e.Id)
    			.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
    
    		c.Property(e => e.CreatedBy)
    			.IsUnicode(false)
    			.HasMaxLength(255);
    
    		c.Property(e => e.UpdatedBy)
    			.IsUnicode(false)
    			.HasMaxLength(255);
    	});
    
    	modelBuilder.Configurations.Add(new UserConfiguration());
    } 
