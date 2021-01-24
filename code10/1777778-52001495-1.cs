    EmployeeForShortDto ConvertToDto(Employee data)
    {
     var dataDto = new EmployeeForShortDto()
            {
                Id = data.Id,
                EmpCode = data.EmpCode,
                Fname = data.Fname,
                Lname = data.Lname,
                Age = NetCoreWebApplication1.Other.Extension.CalcAge(data.DateBirth)
            };
    }
