                DataTable dt = new DataTable();
              
                string connectionString;
                System.Data.OleDb.OleDbConnection excelConnection;
                System.Data.OleDb.OleDbDataAdapter da;
                DataTable dbSchema;
                string firstSheetName;
                string strSQL;
              
                connectionString = @"provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filename + @";Extended Properties=""Excel 12.0;HDR=YES;IMEX=1""";
                excelConnection = new System.Data.OleDb.OleDbConnection(connectionString);
                excelConnection.Open();
                dbSchema = excelConnection.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null);
                firstSheetName = dbSchema.Rows[0]["TABLE_NAME"].ToString();
                strSQL = "SELECT * FROM [" + firstSheetName + "]";
                da = new OleDbDataAdapter(strSQL, excelConnection);
                da.Fill(dt);
    
                da.Dispose();
                excelConnection.Close();
                excelConnection.Dispose();
                
