    SqlDataAdapter da = new SqlDataAdapter(quryString, con);
    DataSet ds = new DataSet();
    da.Fill(ds, "Emp");
    
    //dataGridView1.DataSource = ds.Tables["Emp"];
    dataGridView1.Columns.Add("EmpID", "ID");
    dataGridView1.Columns.Add("FirstName", "FirstName");
    dataGridView1.Columns.Add("LastName", "LastName");
    int row = ds.Tables["Emp"].Rows.Count - 1;
    
    for (int r = 0; r<= row; r++)
    {
    dataGridView1.Rows.Add();
    dataGridView1.Rows[r].Cells[0].Value = ds.Tables["Emp"].Rows[r].ItemArray[0];
    dataGridView1.Rows[r].Cells[1].Value = ds.Tables["Emp"].Rows[r].ItemArray[1];
    dataGridView1.Rows[r].Cells[2].Value = ds.Tables["Emp"].Rows[r].ItemArray[2];
    
    }
