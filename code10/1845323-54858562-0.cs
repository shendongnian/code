        ApplicationDbContext context = new ApplicationDbContext();
        var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
        var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
        UserManager.UserValidator = new UserValidator<ApplicationUser>(UserManager)
        {
            AllowOnlyAlphanumericUserNames = false,
            RequireUniqueEmail = true
        };
        string password = System.Web.Security.Membership.GeneratePassword(12, 4);
        var user = new ApplicationUser();
        user.Email = model.Email;
        user.UserName = model.Email;
        string userPWD = password;
        var result = UserManager.Create(user, userPWD);
