    public partial class EmployeeContext : DbContext
    {
        public EmployeeContext()
            : base("name=EmployeeDatabaseConnectionString")
        {
        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
        
        public virtual DbSet<Sector> Sectors { get; set; }
    }
