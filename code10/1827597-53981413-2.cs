      public SeedDataBase(IServiceProvider _serviceProvider, ApplicationDbContext _context)
        {
            serviceProvider = _serviceProvider;
            context = _context;
            
        }
        private IServiceProvider serviceProvider;
        private ApplicationDbContext context;
        private ApplicationUser superUser;
        public async Task Seed()
        {
          
            await CreateSuperUser();
            await SeedDb();
        }
        private async Task CreateSuperUser()
        {
            var _userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var userExists = await _userManager.GetUsersInRoleAsync("FULLADMIN");
            if (userExists.Count() < 1)
            {
                var _roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var _signinManger = serviceProvider.GetRequiredService<SignInManager<ApplicationUser>>();
                superUser = new ApplicationUser()
                {
                    UserName = "superuser@superuser.com",
                    Email = "superuser@superuser.com",
                    FirstName = "Super",
                    LastName = "User",
                    AccountCreationDate = DateTime.Now.ToShortDateString(),
                    Access = ApplicationUser.Permissions.FullAdmin
                };
                var permissions = Enum.GetNames(typeof(ApplicationUser.Permissions));
                foreach (var s in permissions)
                {
                    await _roleManager.CreateAsync(new IdentityRole(s));
                }
                await _userManager.CreateAsync(superUser, "SecureP@ssword1234");
                await _userManager.AddToRoleAsync(superUser, Enum.GetName(typeof(ApplicationUser.Permissions), superUser.Access));
            }
        }
        
