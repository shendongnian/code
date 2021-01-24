    public class ApplicationDbContext : IdentityDbContext<User>
    {
         public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
         {
         }
    }
