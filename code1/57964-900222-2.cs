    DataGridView dataGridView = new DataGridView();
    dataGridView.AutoGenerateColumns = false;
    DataGridViewColumn columnA = new DataGridViewTextBoxColumn();
    columnA.DataPropertyName = "propertyA";
    columnA.HeaderText = "Column A";
    columnA.Name = "columnA";
    
    DataGridViewColumn columnB = new DataGridViewTextBoxColumn();
    columnB.DataPropertyName = "propertyB";
    columnB.HeaderText = "Column B";
    columnB.Name = "columnB";
    
    dataGridView.Columns.Clear();
    dataGridView.Columns.Add(columnA);
    dataGridView.Columns.Add(columnB);
    dataGridView.AutoResizeColumns();
