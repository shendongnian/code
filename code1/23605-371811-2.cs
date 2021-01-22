    OleDbConnection conn = new OleDbConnection(connectionString);
    conn.Open();
    DataTable queries = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Procedures, null);
    
    conn.Close();
