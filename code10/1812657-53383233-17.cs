    var createdUser = userManager.FindByEmail(newUser.Email);
    var provider = new CertificateProtectionProvider();
    var protector = provider.Create("ResetPassword");
    userManager.UserTokenProvider = new CertificateProtectorTokenProvider<ApplicationUser, int>(protector);
    var token = userManager.GeneratePasswordResetToken(createdUser.Id);
