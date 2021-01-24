    [HttpGet]
    [AllowAnonymous]
    [Route("testReset")]
    public IHttpActionResult TestResetAdminDomain()
    {
        var db = new ApplicationDbContext();
        var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
        var provider = new DpapiDataProtectionProvider("ASP.NET Identity");
        manager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(
            provider.Create("ASP.NET Identity"));
        var email = "test@test.com";
        var user = new ApplicationUser() { UserName = email, Email = email };
        var identityUser = manager.FindByEmail(email);
        if (identityUser == null)
        {
            manager.Create(user);
            identityUser = manager.FindByEmail(email);
        }
        var token = manager.GeneratePasswordResetToken(identityUser.Id);
        return Ok(HttpUtility.UrlEncode(token));
    }
    [HttpGet]
    [AllowAnonymous]
    [Route("testReset")]
    public IHttpActionResult TestResetClientDomain(string token)
    {
        var db = new ApplicationDbContext();
        var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
        var provider = new DpapiDataProtectionProvider("ASP.NET Identity");
        manager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(
            provider.Create("ASP.NET Identity"));
        var email = "test@test.com";
        var identityUser = manager.FindByEmail(email);
        var valid = Task.Run(() => manager.UserTokenProvider.ValidateAsync("ResetPassword", token, manager, identityUser)).Result;
        var result = manager.ResetPassword(identityUser.Id, token, "TestingTest1!");
        return Ok(result);
    }
