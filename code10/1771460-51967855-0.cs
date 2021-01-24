    // Create a "Products" DataTable object.
    DataTable sourceTable = new DataTable("Products");
    sourceTable.Columns.Add("Product", typeof(string));
    sourceTable.Columns.Add("Price", typeof(float));
    sourceTable.Columns.Add("Quantity", typeof(Int32));
    
    sourceTable.Rows.Add("Chocolade", 5, 15);
    sourceTable.Rows.Add("Konbu", 9, 55);
    sourceTable.Rows.Add("Geitost", 15, 70);
    
    // Bind the worksheet to the created DataTable.
    worksheet.DataBindings.BindToDataSource(sourceTable, 1, 1);
