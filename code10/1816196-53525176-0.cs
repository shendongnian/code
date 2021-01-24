    class Program
        {
            static void Main(string[] args)
            {
                List<Department> deps = new List<Department>();
                Department finanace = new Department { Id = 1, Name = "Finance & Accounting" };
                deps.Add(finanace);
                Department hr = new Department { Id = 2, Name = "People - HR" };
                deps.Add(hr);
    
                List<Employee> emps = new List<Employee>();
                emps.Add(new Employee { Id = 1, Name = "Finance Person 1", Department = finanace });
                emps.Add(new Employee { Id = 2, Name = "Finance Person 2", Department = finanace });
                emps.Add(new Employee { Id = 3, Name = "HR Person 1", Department = hr });
                emps.Add(new Employee { Id = 4, Name = "HR Person 2", Department = hr });
    
    
                var grouped =
                    deps.GroupJoin(emps,
                       dept => dept,
                       emp => emp.Department,
                       (dept, employeeList) =>
                       new
                       {
                           DepartmentName = dept.Name,
                           Employees = employeeList.Select(employee => employee.Name)
                       });
    
    
                foreach (var dept in grouped)
                {
                    Console.WriteLine(dept.DepartmentName);
    
                    foreach (var emp in dept.Employees)
                    {
                        Console.WriteLine(emp);
                    }
    
                    Console.WriteLine();
                }
    
                Console.ReadLine();
            }
        }
    
    
        public class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int DepartmentId { get; set; }
            public Department Department { get; set; }
        }
    
    
        public class Department
        {
            public int Id { get; set; }
            public string Name { get; set; }
    
        }
