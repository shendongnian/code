    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Employee> Subordinates { get; set; }
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
