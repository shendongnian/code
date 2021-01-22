    class Program
    {
        class Employee { public string LastName { get; set; } }
        static void Main(string[] args)
        {
            List<Employee> employeeList = new List<Employee>();
            employeeList.Add(new Employee(){LastName="Something"});
            employeeList.Add(new Employee(){LastName="Something Else"});
            int index = employeeList.FindIndex(delegate(Employee employee) 
                               { return employee.LastName.Equals("Something"); });
            Console.WriteLine("Index:{0}", index);
            Console.ReadKey();
        }
    }
