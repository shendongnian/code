     public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
            {
            }
    
            protected override void OnModelCreating(ModelBuilder builder)
            {
                base.OnModelCreating(builder);
                //....
            }
        public DbSet<Student> Students{ get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        //....
        }
