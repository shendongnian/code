    /// This is the aggregate root
    public class Company
    {
        public string Name { get; set; }
        public IList<Employee> Employees { get; private set; }
        public Employee ContactPerson { get; set; }
    }
    /// This isn't    
    public class Employee
    {
        public string FullName { get; set; }
    }
