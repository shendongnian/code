    public void UpdateEmployeeList()
    {
        lstResults.Items.Clear();
        foreach (Employees values in employeeRegistry.employeerList)
        {
           lstResults.Items.Add(values);
        }
    }
