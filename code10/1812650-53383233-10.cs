    var provider = new CertificateProtectionProvider();
    var protector = provider.Create("ResetPassword");
    userManager.UserTokenProvider = new CertificateProtectorTokenProvider<ApplicationUser, int>(protector);
    if (!await UserManager.UserTokenProvider.ValidateAsync("ResetPassword", model.Token, UserManager, user))
    {
        return GetErrorResult(IdentityResult.Failed());
    }
    var result = await userManager.ResetPasswordAsync(user.Id, model.Token, model.NewPassword);
