    DataTable dt = new DataTable();
    dataGridView2.DataSource = dt;
    
    DataGridViewComboBoxColumn newColumn = new DataGridViewComboBoxColumn();
    
    newColumn.DataSource = new List<string> { "asd", "qwe", "zxc" };
    
    dataGridView2.Columns.Add(newColumn);
