    public class ApplicationIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationIdentityDbContext (DbContextOptions<ApplicationIdentityDbContext> options): base(options)
        {
        }
    }
