    DataTable dt = new DataTable();
    dt.Columns.Add("My first column Name");
 
    dt.Rows.Add(new object[] { "Item 1" });
    dt.Rows.Add(new object[] { "Item number 2" });
    dt.Rows.Add(new object[] { "Item number three" });
 
    myDataGridView.DataSource = dt;
