    public class AppDbContext : IdentityDbContext<AppUser>, IAppDbContext
    {
        ...
        public Task<int> SaveChangesAsync() => base.SaveChangesAsync();
    }
