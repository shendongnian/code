    Public DataTable GetAllEmployees()
    {
        Employee.EmployeeTableAdapter adapt = New Employee.EmployeeTableAdapter();
        DataTable dt = New DataTable();
        dt =    adapt.GetData();   // you can also use fill based on your criteria.
        return dt;   //your datatable with data
    }
