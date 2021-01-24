    List<Employee> Employees = new List<Employee>();
    List<string> firstnames = new List<string>()
    {
        "Bob", "Jeff", "Dale", "Kate", "Ann"
    };
    
    List<string> lastnames = new List<string>()
    {
        "Jackson", "Smith", "Miller", "Turner", "Johnson"
    };
    
    List<int> IDs = new List<int>()
    {
        34332, 54754, 43523, 87012, 43158
    };
    
    List<int> indexes = new List<int>()
    {
        0, 1, 2, 3, 4
    };
    
    foreach (int index in indexes)
    {
        Employee Employeeobject = new Employee();
        Employeeobject.firstname = firstnames[index];
        Employeeobject.lastname = lastnames[index];
        Employeeobject.ID = IDs[index];
        Employees.Add(Employeeobject);
    }
    
    foreach (Employee Employee in Employees)
    {
        Console.WriteLine(Employee.firstname + " " + Employee.lastname + " " + Employee.ID);
    }
    Console.ReadLine();
