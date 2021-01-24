    using (var db = new ProjectContext())
    {
    	var project = new Project();
    	project.Name = "My project";
    
    	// assumes there's 3 owners and 2 products already inserted in the DB
    
    	// Add the 3 owners to the project
    	project.ProjectOwners.Add(new ProjectOwner { OwnerId = 1});
    	project.ProjectOwners.Add(new ProjectOwner { OwnerId = 2});
    	project.ProjectOwners.Add(new ProjectOwner { OwnerId = 3});
    	
    	// Add Product 1 to Owner 1 and 2
    	project.ProjectProductOwners.Add(new ProjectProductOwner { ProductId = 1, OwnerId = 1 });
    	project.ProjectProductOwners.Add(new ProjectProductOwner { ProductId = 1, OwnerId = 2 });
    
    	// Add Product 2 to Owner 1 and 3
    	project.ProjectProductOwners.Add(new ProjectProductOwner { ProductId = 2, OwnerId = 1 });
    	project.ProjectProductOwners.Add(new ProjectProductOwner { ProductId = 2, OwnerId = 3 });
    
    	db.Add(project);
    	db.SaveChanges();
    
    	var projects = db.Project
    		.Include(p => p.ProjectOwners)
    		.ThenInclude(p => p.Owner)
    		.Include(p => p.ProjectProductOwners)
    		.ThenInclude(p => p.Product)
    		.FirstOrDefault();
    }
