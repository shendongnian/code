    public interface IApplicationUserStore
    {
        Task<IdentityResult> Create(ApplicationUser user, string password);
        Task<ApplicationUser> Get(string email);
    }
