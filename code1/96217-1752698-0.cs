    // Create a new Combo Box Column
    DataGridViewComboBoxColumn EmpIdColumn = new DataGridViewComboBoxColumn();
    // Set the DataSource of EmpIdColumn as bellow
    EmpIdColumn.DataSource = myDataSet.Tables[0];
    // Set the ValueMember property as done bellow 
    EmpIdColumn.ValueMember = myDataSet.Tables[0].Columns[0].ColumnName.ToString();
    // Set the DisplayMember property as follow
    EmpIdColumn.DisplayMember = EmpIdColumn.ValueMember;
