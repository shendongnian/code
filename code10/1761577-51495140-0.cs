     public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var userStore = new CustomUserStore(new ApplicationDbContext());
            var manager = new UserManager<ApplicationUser, long>(userStore);
            var user = await manager.FindAsync(context.UserName, context.Password);
            if (user != null)
            {
                // var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                ClaimsIdentity identity = await user.GenerateUserIdentityAsync(manager);
                identity.AddClaim(new Claim("UserId", user.Id.ToString()));
                identity.AddClaim(new Claim("Username", user.UserName.ToString()));
                identity.AddClaim(new Claim("Email", user.Email));
                identity.AddClaim(new Claim("UserRole", new RoleManagerBusinessLogic().GetRoleNameByRoleId(user.Roles.FirstOrDefault().RoleId)));
                identity.AddClaim(new Claim("LoggedOn", DateTime.UtcNow.ToString()));
                context.Validated(identity);
            }
            else
                return;
        }
