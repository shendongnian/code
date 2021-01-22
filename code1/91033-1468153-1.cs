     excelConnection = new System.Data.OleDb.OleDbConnection(connectionString);
            excelConnection.Open();
            dbSchema = excelConnection.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null);
            firstSheetName = dbSchema.Rows[0]["TABLE_NAME"].ToString();
            strSQL = "SELECT * FROM [" + firstSheetName + "]";
            da = new OleDbDataAdapter(strSQL, excelConnection);
            da.Fill(dt);
