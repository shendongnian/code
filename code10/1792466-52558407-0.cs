    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<AspNetUsersExtendedDetails> AspNetUsersExtendedDetails { get; set; }
        public virtual DbSet<AspNetApplications> AspNetApplications { get; set; }
        public virtual DbSet<AspNetEventLogs> AspNetEventLogs { get; set; }
        public virtual DbSet<AspNetRolesExtendedDetails> AspNetRolesExtendedDetails { get; set; }
        public virtual DbSet<AspNetUserRolesExtendedDetails> AspNetUserRolesExtendedDetails { get; set; }
        public virtual DbSet<AspNetUserAccessTokens> AspNetUserAccessTokens { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
    
        }
    }
