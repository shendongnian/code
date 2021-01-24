    services.AddIdentity<ApplicationUser, IdentityRole>()
    	.AddEntityFrameworkStores<ApplicationDbContext>()
    	.AddDefaultTokenProviders()
    	.AddDefaultUI();
    
    services.AddIdentityCore<StudentUser>()
    	.AddRoles<IdentityRole>()
    	.AddClaimsPrincipalFactory<UserClaimsPrincipalFactory<StudentUser, IdentityRole>>()
    	.AddEntityFrameworkStores<ApplicationDbContext>()
    	.AddDefaultTokenProviders()
    	.AddDefaultUI();
    
    services.AddIdentityCore<EmployeeUser>()
    	.AddRoles<IdentityRole>()
    	.AddClaimsPrincipalFactory<UserClaimsPrincipalFactory<EmployeeUser, IdentityRole>>()
    	.AddEntityFrameworkStores<ApplicationDbContext>()
    	.AddDefaultTokenProviders()
    	.AddDefaultUI();
    
