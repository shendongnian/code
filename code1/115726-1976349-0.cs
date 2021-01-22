    dataGridView1.Columns.Add("Column1", "Column1");
    dataGridView1.Columns.Add("Column2", "Column2");            
    dataGridView1.Columns.Add("Column3", "Column3");
    //this is the key line...to allow \n in column
    dataGridView1.Columns[2].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
    dataGridView1.Rows.Add(new object[] { 1, "v1  v2", "vl1\nvl2\nvl3" });
    dataGridView1.Rows.Add(new object[] { 2, "v3  v4", "vl4\nvl5\nvl6" });
