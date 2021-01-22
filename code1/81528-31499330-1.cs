    class Employee
    {
        public string Name { get; set; }
        public int EmployeeID { get; set; }
    }
            //Add 5 employees to List
            List<Employee> lst = new List<Employee>();
            Employee e = new Employee { Name = "Shantanu", EmployeeID = 123456 };
            lst.Add(e);
            lst.Add(e);
            Employee e1 = new Employee { Name = "Adam Warren", EmployeeID = 123456 };
            lst.Add(e1);
            //Add a space in the Name
            Employee e2 = new Employee { Name = "Adam  Warren", EmployeeID = 123456 };
            lst.Add(e2);
            //Name is different case
            Employee e3 = new Employee { Name = "adam warren", EmployeeID = 123456 };
            lst.Add(e3);            
            //Distinct (without IEqalityComparer<T>) - Returns 4 employees
            var lstDistinct1 = lst.Distinct();
            //Extension - Return 2 employees
            var lstDistinct = lst.Distinct(employee => 
                                        employee.EmployeeID.GetHashCode() ^ employee.Name.ToUpper().Replace(" ", "").GetHashCode()
                                    );
    
