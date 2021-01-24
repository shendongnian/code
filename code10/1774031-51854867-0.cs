    DataTable table = new DataTable();
    DataRow row;
    DataColumn column;         
    // Create new DataColumn, set DataType, ColumnName and add to DataTable.    
    column = new DataColumn();
    column.DataType = System.Type.GetType("System.Int32");
    column.ColumnName = "ValueMember";
    table.Columns.Add(column);
    // Create second column.
    column = new DataColumn();
    column.DataType = Type.GetType("System.String");
    column.ColumnName = "DisplayMember";
    table.Columns.Add(column);
    row = table.NewRow();
    row["ValueMember"] = 1;
    row["DisplayMember"] = "item";
    table.Rows.Add(row);
    comboBox1.DataSource = null;
    comboBox1.DataSource = table;
    comboBox1.DisplayMember = "DisplayMember";
    comboBox1.ValueMember = "ValueMember";
