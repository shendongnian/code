    grid.AutoGenerateColumns = false;
    
    DataGridViewColumn colID = new DataGridViewTextBoxColumn();
    colID.DataPropertyName = "customerID";
    colID.HeaderText = "Ident.";
    grid.Columns.Add(colID);
    
    DataGridViewColumn colName = new DataGridViewTextBoxColumn();
    colName.DataPropertyName = "customerFirstName";
    colName.HeaderText = "First name";
    grid.Columns.Add(colName);
    
    grid.DataSource = dataSet.Tables[0].DefaultView;
