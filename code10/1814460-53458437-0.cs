    public interface IMYUserManager
    {
        Task<IdentityUser> FindByIdAsync(string uniqueid);
        Task<IdentityResult> CreateAsync(IdentityUser IdentityUser);
        Task<IdentityResult> UpdateAsync(IdentityUser IdentityUser);
        Task<IdentityResult> DeleteAsync(IdentityUser result);
    }
