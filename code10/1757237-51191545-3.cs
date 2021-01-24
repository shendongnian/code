     public void ConfigureServices(IServiceCollection services)
     {
         ...
         services.AddIdentity<User, IdentityRole>()
             .AddEntityFrameworkStores<ApplicationDbContext>()
             .AddSignInManager<SignInManager<User>>()
             .AddUserManager<UserManager<User>>();
         ...
     }
