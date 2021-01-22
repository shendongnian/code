    DataGridView dataGridView = new DataGridView();
    DataGridViewColumn columnA = new DataGridViewTextBoxColumn();
    columnA.HeaderText = "Column A";
    columnA.Name = "columnA";
    
    DataGridViewColumn columnB = new DataGridViewTextBoxColumn();
    columnB.HeaderText = "Column B";
    columnB.Name = "columnB";
    
    dataGridView.Columns.Clear();
    dataGridView.Columns.Add(columnA);
    dataGridView.Columns.Add(columnB);
    dataGridView.AutoResizeColumns();
