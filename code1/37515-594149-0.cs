    // Set the data source.
    dataGridView1.DataSource = dataTable1;
    
    // Create a new text box column.
    DataGridViewColumn c1 = new DataGridViewTextBoxColumn();
    const string C1_COL_NAME = "Custom1";
    c1.Name = C1_COL_NAME;
    
    // Insert the new column where needed.
    dataGridView1.Columns.Insert(1, c1);
    
    // Text can then be placed in the rows of the new column.
    dataGridView1.Rows[0].Cells[C1_COL_NAME].Value = "Some text...";
