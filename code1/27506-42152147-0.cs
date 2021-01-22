    namespace GenaricClass
    {
        class Employee :IComparable<Employee>
        {
            public string Name { get; set; }
            public double Salary { get; set; }
            public int CompareTo(Employee other)
            {
                if (this.Salary < other.Salary) return 1;
                else if (this.Salary > other.Salary) return -1;
                else return 0;
            }
            public static void Main()
            {
                List<Employee> empList = new List<Employee>()
                {
                    new Employee{Name="a",Salary=140000},
                    new Employee{Name="b",Salary=120000},
                    new Employee{Name="c",Salary=160000},
                    new Employee{Name="d",Salary=10000}
                };
                empList.Sort();
                foreach (Employee emp in empList)
                {
                    System.Console.Write(emp.Salary +",");
                }
                System.Console.ReadKey();
            }
        }
    }
