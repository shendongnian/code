    DataTable table = new DataTable();
    
    string[] column = { "DateCreated", "DepthCode", "DepthDateCreated" };
    
    foreach (var item in column)
    {
        DataColumn datecolumn = new DataColumn(item);
        datecolumn.AllowDBNull = true;
        table.Columns.Add(item);
    }
