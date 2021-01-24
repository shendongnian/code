    string column1;
    string column2;
    string column3;
    SqlCommand cmd = new SqlCommand("Select * from TableName WHERE employeename='" + employee.Text + "'", connectionString);
    SqlDataReader reader = cmd.ExecuteReader;
    while (dr.read)
    {
        
        column2 = dr(1).ToString;
        column3 = dr(2).ToString
    }
     column1 = employeename.Text;
     DataGridViewRow row = (DataGridViewRow)yourDataGridView.Rows[0].Clone();
     row.Cells[0].Value = column1;
     row.Cells[1].Value = column2;
     row.Cells[2].Value = column3;
     yourDataGridView.Rows.Add(row);
    
    
