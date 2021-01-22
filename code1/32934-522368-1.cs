    public Company AddEmployee(Employee employee)
    {
        var newEmployeeList = new List(EmployeeList); 
        newEmployeeList.Add(employee);
        return new Company(newEmployeeList.AsReadOnly(), ....)
    }
