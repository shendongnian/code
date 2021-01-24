    public class CompanyDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
    public class Department
    {
        public long Id { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
    public class Employee
    {
        public long Id { get; set; }
        public long DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
    
