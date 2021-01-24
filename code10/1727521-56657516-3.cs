    protected override void OnModelCreating(ModelBuilder builder)
    {
    	base.OnModelCreating(builder);
    
    	builder.Seed(new List<Tenant> {
    		new Tenant() {TenantID = 0 , Name = string.Empty},
    		new Tenant() {TenantID = 1 , Name = "test"}
    		//....
    		);
    		
    	//....
    }
