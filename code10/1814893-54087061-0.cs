        services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(
            Configuration.GetConnectionString("DefaultConnection")));
    services.AddDefaultIdentity<IdentityUser>().AddRoles<IdentityRole>() <--Here!!!
         .AddEntityFrameworkStores<ApplicationDbContext>();
