    OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\1.xlsx;Extended Properties=Excel 8.0");
    connection.Open();
    DataTable dataTable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
    
    if (dataTable == null) return;
    
    foreach (DataColumn column in dataTable.Columns)
      Console.Write(column.ColumnName + '\t');
    Console.Write('\n');
    foreach (DataRow row in dataTable.Rows)
    {
      foreach (DataColumn column in dataTable.Columns)
        Console.Write(row[column].ToString() + '\t');
      Console.Write('\n');
    }
