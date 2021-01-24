    public partial class EmployeeUserContext : DbContext
    {
        public EmployeeUserContext()
            : base("name=EmployeeUserDatabaseConnectionString")
        {
        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
        
        public virtual DbSet<User> Users { get; set; }
    }
