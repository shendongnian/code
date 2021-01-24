    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    	// Configure Owners in a Project
    	modelBuilder.Entity<ProjectOwner>()
    		.HasKey(p => new { p.ProjectId, p.OwnerId });
    
    	modelBuilder.Entity<ProjectOwner>()
    		.HasOne(bc => bc.Project)
    		.WithMany(b => b.ProjectOwners)
    		.HasForeignKey(bc => bc.ProjectId);
    
    	modelBuilder.Entity<ProjectOwner>()
    		.HasOne(bc => bc.Owner)
    		.WithMany(c => c.ProjectOwners)
    		.HasForeignKey(bc => bc.OwnerId);
    
    	// Configure Products for each owner in a Project
    	modelBuilder.Entity<ProjectProductOwner>()
    		.HasKey(p => new { p.ProjectId, p.ProductId, p.OwnerId });
    
    	modelBuilder.Entity<ProjectProductOwner>()
    		.HasOne(bc => bc.Project)
    		.WithMany(b => b.ProjectProductOwners)
    		.HasForeignKey(bc => bc.ProjectId);
    
    	modelBuilder.Entity<ProjectProductOwner>()
    		.HasOne(bc => bc.Product)
    		.WithMany(c => c.ProjectProductOwners)
    		.HasForeignKey(bc => bc.ProductId);
    
    	modelBuilder.Entity<ProjectProductOwner>()
    		.HasOne(bc => bc.Owner)
    		.WithMany(c => c.ProjectProductOwners)
    		.HasForeignKey(bc => bc.OwnerId);
    }
