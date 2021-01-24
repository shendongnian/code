    public class MultiTenantValidator : IUserValidator<ApplicationUser>
    {
        public async Task<IdentityResult> ValidateAsync(UserManager<ApplicationUser> manager, ApplicationUser user)
        {
            bool combinationExists = manager.Users
                .AnyAsync(x => x.UserName == user.UserName 
                            && x.Email == user.Email
                            && x.TenantId == user.TenantId);
            if (combinationExists)
            {
                return IdentityResult.Failed(new IdentityResult { Description = "The specified username and email are already registered in the given tentant" });
            }
            // here the default validator validates the username for valid characters,
            // let's just say all is good for now
            return IdentityResult.Success;
        }
    }
