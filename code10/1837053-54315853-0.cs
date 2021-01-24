    public class EmployeeContext : DbContext
    {
        public EmployeeContext()
            : base("EmployeeContext")
        {
    
        }
    
        // DbSet's here
        publlic DbSet<Employee> Employees { get; set; }
    }
