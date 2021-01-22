    // Create a DataTable
    DataTable table = new DataTable()
    ...
    // Filter and Sort expressions
    string expression = "[Birth Year] >= 1983"; 
    string sortOrder = "[Birth Year] ASC";
    // Create a DataView using the table as its source and the filter and sort expressions
    DataView dv = new DataView(table, expression, sortOrder, DataViewRowState.CurrentRows);
    // Convert the DataView to a DataTable
    DataTable new_table = dv.ToTable("NewTableName");
