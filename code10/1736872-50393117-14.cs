    protected override void OnModelCreating(ModelBuilder ModelBuilder)
    {
    	base.OnModelCreating(ModelBuilder);
    
    	ModelBuilder.Entity<User>(Entity =>
    	{
    		Entity.HasKey(E => E.AccountId);
    		Entity.ToTable("Users");
    	});
    }
