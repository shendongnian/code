    DataTable table = new DataTable(); 
    DataColumn col = table.Columns.Add("RowNumber", typeof(int)); 
    col.AutoIncrementSeed = 1; 
    col.AutoIncrement = true; 
    DataTable origin = new DataTable(); 
    DataColumnCollection columns = origin.Columns; 
    columns.Add("Id", typeof(int)); 
    columns.Add("Name", typeof(string)); 
    origin.Rows.Add(55, "Foo"); 
    origin.Rows.Add(14, "Bar"); 
    table.Load(origin.CreateDataReader()); 
    // Examine table through the debugger. Is will have the contents 
    // of "origin" with the column "RowNumber" prepended.
