    protected override void Initialize(RequestContext requestContext)
    {
        using (var ac  = new ApplicationDbContext())
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(ac));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(ac));
            var user = new ApplicationUser { UserName = "hello@gmail.com", Email = "hello@gmail.com"};
            userManager.Create(user, "Hello1234!");
            roleManager.Create(new IdentityRole("admin"));
            user = userManager.FindByUserName(user.UserName);
            userManager.AddToRole(user.Id, "admin");
        }
    }
