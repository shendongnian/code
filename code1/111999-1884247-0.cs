    LoadEmployeeCommand()
    {
        // The Load method initiates the call to the server
        LoadOperation<Employee> loadOperation = domainContext.Load(domainContext.GetEmployeesQuery());
        // The EntitySet is still empty at this point
        employeeDataGrid.ItemsSource = domainContext.Employees; 
        loadOperation.Completed += EmployeeLoadOperationCompleted;
    }
    private void EmployeeLoadOperationCompleted(object sender, EventArgs e)
    {
        // Don't need to reassign now but at this point the collection should be populated
        employeeDataGrid.ItemsSource = domainContext.Employees;
    }
