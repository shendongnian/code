    DataRow row; 
    // Create new DataColumn, set DataType, ColumnName and add to DataTable.    
    column = new DataColumn();
    column.DataType = System.Type.GetType("System.String");
    column.ColumnName = "Whatever";
    table.Columns.Add(column);
