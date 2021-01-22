    grid.AutoGenerateColumns = false;
                
    DataGridViewColumn col = new DataGridViewTextBoxColumn();
    col.DataPropertyName = "Prop1";
    col.HeaderText = "Property 1";
    grid.Columns.Add(col);
    
    col = new DataGridViewTextBoxColumn();
    col.DataPropertyName = "Prop2";
    col.HeaderText = "Property 2";
    grid.Columns.Add(col);
                
    grid.DataSource = dataSet.Tables[0].DefaultView;
