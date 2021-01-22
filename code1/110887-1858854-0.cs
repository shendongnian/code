    String connect = "Provider=Microsoft.JET.OLEDB.4.0;data source=.\\Employee.mdb";
    OleDbConnection con = new OleDbConnection(connect);
    con.Open();  
    Console.WriteLine("Made the connection to the database");
    
    Console.WriteLine("Information for each table contains:");
    DataTable tables = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables,new object[]{null,null,null,"TABLE"});
    
    Console.WriteLine("The tables are:");
    foreach(DataRow row in tables.Rows) 
      Console.Write("  {0}", row[2]);
    con.Close();
