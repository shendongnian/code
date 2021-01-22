    public void PopulateDataTable()
    {
          DataTable dt = GetEmployee();
          Employee dsEmployee = New DataSet();
          dsEmployee.EmployeeDataTable dtEmp = new dsEmployee.EmployeeDataTable();
          dtEmp = dt;
    }
