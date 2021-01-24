    services.AddIdentity<ApplicationUser, IdentityRole>()
    	.AddEntityFrameworkStores<ApplicationDbContext>()
    	.AddDefaultTokenProviders()
    	.AddDefaultUI();
    
    services.AddIdentityCore<StudentUser>()
    	.AddClaimsPrincipalFactory<UserClaimsPrincipalFactory<StudentUser, IdentityRole>>()
    	.AddEntityFrameworkStores<ApplicationDbContext>()
    	.AddDefaultTokenProviders()
    	.AddDefaultUI();
    
    services.AddIdentityCore<EmployeeUser>()
    	.AddClaimsPrincipalFactory<UserClaimsPrincipalFactory<EmployeeUser, IdentityRole>>()
    	.AddEntityFrameworkStores<ApplicationDbContext>()
    	.AddDefaultTokenProviders()
    	.AddDefaultUI();
