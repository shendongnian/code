    DataTable EmployeeTable = ds.Tables["table1"];  
    DataRow row = EmployeeTable.rows[Radgrid.selectedIndex];  
    row["Fname"] = txtFname.Text.ToString();  
    row["Lname"] = txtLname.Text.ToString();  
    row["Designation"] = txtDesignation.Text.ToString();  
    EmployeeTable.Rows.Add(row);  
    da.Update(ds, "table1");  
