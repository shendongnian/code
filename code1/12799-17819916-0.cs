    // this is better suited for expensive object creation/initialization
    IEnumerable<Employee> ParseEmployeeTable(DataTable dtEmployees)
    {
        var employees = ConcurrentBag<Employee>();
    
        Parallel.ForEach(dtEmployees.AsEnumerable(), (dr) =>
        {
            employees.Add(new Employee() 
            {
                _FirstName = dr["FirstName"].ToString(),
                _LastName = dr["Last_Name"].ToString()
            });
        });
    
        return employees;
    }
