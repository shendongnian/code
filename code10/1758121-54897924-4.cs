    public virtual async Task SignOutAsync()
    {
        await Context.SignOutAsync(IdentityConstants.ApplicationScheme);
        await Context.SignOutAsync(IdentityConstants.ExternalScheme); //<- Problem and...
        await Context.SignOutAsync(IdentityConstants.TwoFactorUserIdScheme); //... another problem.
    }
