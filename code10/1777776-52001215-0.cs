    List<EmployeeForShortDto> result = new List<EmployeeForShortDto>();
    foreach(Employee dbEmployee in data )
    {
     result.add(new EmployeeForShortDto()
                {
                    Id = dbEmployee .Id,
                    EmpCode = dbEmployee .EmpCode,
                    Fname = dbEmployee .Fname,
                    Lname = dbEmployee .Lname,
                    Age = NetCoreWebApplication1.Other.Extension.CalcAge(dbEmployee .DateBirth)
                });
    }
