    OleDbConnection conn = new OleDbConnection(connectionString);
    conn.Open();
    DataTable queries = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Views, null);
    
    conn.Close();
