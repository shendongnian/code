    String connect = "Provider=Microsoft.JET.OLEDB.4.0;data source=.\\Employee.mdb";
    OleDbConnection con = new OleDbConnection(connect);
    con.Open();  
    Console.WriteLine("Made the connection to the database");
    
    Console.WriteLine("Information for each table contains:");
    DataTable tables = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables,new object[]{null,null,null,"TABLE"});
    
    foreach(DataRow tableRow in tables.Rows)
    {
        Console.WriteLine("Table Name: {0}", tableRow[0]);
        DataTable cols = con.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, new Object[]{null,null, tableRow[0], null});
        foreach (DataRow colRow in cols.Rows)
        {
            Console.WriteLine("Column Name: {0}", colRow[0]);
        }
    }
    con.Close();
