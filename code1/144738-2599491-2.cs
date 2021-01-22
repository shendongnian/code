        public class Company
        {
            private readonly List<Employee> employees = new List<Employee>();
            public List<Employee> Employees { get { return employees;}}
        }
        public class Employee
        {
            public string EmployeeName {get;set;}
            public string Designation {get;set;}
        }
