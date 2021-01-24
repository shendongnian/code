    var context = ApplicationDbContext.Create();
    UserManager<ApplicationUser> UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
    ApplicationUser user = await UserManager.FindByNameAsync(username);
    IdentityResult result = null;
    if (user != null)
    {
        context.Entry(user).State = System.Data.EntityState.Modified;
        user.Email="foo";
        result = await UserManager.UpdateAsync(user);
    }
