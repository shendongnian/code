    List<Employee> employees = new List<Employee>()
    {
        new Employee{Id =1,Name="AAAAA"}
        , new Employee{Id =2,Name="BBBBB"}
        , new Employee{Id =3,Name="AAAAA"}
        , new Employee{Id =4,Name="CCCCC"}
        , new Employee{Id =5,Name="AAAAA"}
    };
    List<Employee> duplicateEmployees = employees.Except(employees.GroupBy(i => i.Name)
                                                 .Select(ss => ss.FirstOrDefault()))
                                                .ToList();
