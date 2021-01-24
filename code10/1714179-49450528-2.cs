    public class ApplicationDbContext : 
       IdentityDbContext<ApplicationUser>,  IDbContext
    {
        ...
        public DbSet<Category> Categories { get; set; }
        ...
    }
    
    public interface IDbContext
    {
       DbSet<Category> Categories { get; set; }
       ...
    }
