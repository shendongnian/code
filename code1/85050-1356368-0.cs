    DataTable dt=new DataTable();
    dt.Columns.Add("No",typeof(int)); // Adding column into ColumnsCollection
    dt.Columns.Add("Name");
    
    dt.Rows.Add(1,"AAA");  // Adding rows into RowsCollection
    dt.Rows.Add(2,"BBB");
    
    DataGridView1.DataSource=dt; // Binding datasource
