    hostAdminUser = new ApplicationUser()
    {
        UserName = SetupConsts.Users.Host.UserName,
        Email = SetupConsts.Users.Host.Email,
        EmailConfirmed = true,
        PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(hostAdminUser, SetupConsts.Users.Passwords.Default)
    };
    await _userManager.CreateAsync(hostAdminUser);
