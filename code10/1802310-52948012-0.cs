    if (columnName == "DynamicSearchEmployeeSalary")
    { 
        if (string.IsNullOrWhiteSpace(DynamicSearchEmployeeSalary))
        {
            error += "Employee Salary is required to add a new Employee !";
        }
        
        if (!Int32.TryParse(dynamicSearchEmployeeSalary, out output))
        {
            error += "\r\nEmployee Salary has to be number !";
        }
        
        if (EmployeeSalary < 10)
        {
            error += "\r\nEmployee Salary cannot be less than 10 !";
        }
        if (EmployeeSalary < 100)
        {
            error += "\r\nEmployee Salary cannot be less than 100 !";
        }
    }
