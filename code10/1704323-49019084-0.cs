    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        // Exposed FK. By convention, EF know this is a FK.
        // EF will add one if you omit it.
        public int DepartmentID { get; set; }  
        // Navigation properties are how you access the related (joined) data
        public virtual Department Department { get; set; }  
    }
    public class Department
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
