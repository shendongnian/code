    public abstract class DataContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>, IDataContext
    {
        public DataContext(DbContextOptions options)
        : base(options)
        {
        }
