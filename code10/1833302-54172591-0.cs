     using (OleDbConnection conn = new OleDbConnection(connString))
    {
        conn.Open();
        dtSchema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
        Sheet1= dtSchema.Rows[0].Field<string>("TABLE_NAME");
    }
