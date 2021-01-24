    public static EmployeeForShortDto ToDto(this Employee employee)
    {
        if (employee != null)
        {
            return new EmployeeForShortDto
            {
                Id = employee.Id,
                EmpCode = employee.EmpCode,
                Fname = employee.Fname,
                Lname = employee.Lname,
                Age = NetCoreWebApplication1.Other.Extension.CalcAge(employee.DateBirth)
            };
        }
    
        return null;
    }
