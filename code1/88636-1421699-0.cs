    DataTable dt = new DataTable();
    dt.Columns.Add("No",typeof(int));
    dt.Columns.Add("Name");
    
    dt.Rows.Add(1, "A");
    dt.Rows.Add(2, "B");
    dt.Columns[0].ReadOnly = true;
    
    dataGridView1.EditMode = DataGridViewEditMode.EditOnKeystroke;
    dataGridView1.DataSource =dt;
