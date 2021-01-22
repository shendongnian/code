    DataGridViewColumn myColumn = new DataGridViewTextBoxColumn();
    myColumn.DataPropertyName.HeaderText = "Title of the column";
    myColumn.DataPropertyName = "NameOfTheProperty";
    
    //...
    
    MyDataGridView.Columns.Add(myColumn);
