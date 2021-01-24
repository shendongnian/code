    class Program
        {
           static List<Employee> lstEmployee = new List<Employee>();
            static void Main(string[] args)
            {
                
                Employee emp1 = new Employee();
                emp1.Department = "C Level";
                emp1.EmployeeID = 1;
                emp1.EmployeeLastname = "Smith";
                emp1.EmployeeName = "Joe";
                lstEmployee.Add(emp1);
    
                Employee emp2 = new Employee();
                emp2.Department = "B Level";
                emp2.EmployeeID = 2;
                emp2.EmployeeLastname = "Smith";
                emp2.EmployeeName = "John";
                emp2.ManagerID = 1;
                lstEmployee.Add(emp2);
    
                Employee emp3 = new Employee();
                emp3.Department = "A Level";
                emp3.EmployeeID = 3;
                emp3.EmployeeLastname = "Mallari";
                emp3.EmployeeName = "Lem";
                emp3.ManagerID = 2;
                lstEmployee.Add(emp3);
               
                Console.ReadLine();
            }
    
            public class Employee
            {
                public int EmployeeID { get; set; }
                public string EmployeeName { get; set; }
                public string EmployeeLastname { get; set; }
                public int ManagerID { get; set; }
                public Employee Manager
                {
                    get
                    {
                        return (from a in lstEmployee where a.EmployeeID == ManagerID select a).FirstOrDefault();
                    }
                }
                public List<Employee> Reportees
                {
                    get
                    {
                        return (from a in lstEmployee where a.ManagerID == EmployeeID select a).ToList();
                    }
                }
                public string Department { get; set; }
            }
        }
