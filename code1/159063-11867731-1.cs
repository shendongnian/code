    string full = "C:\\Temp.xls"
                DataTable datatable = null;
                string conString = "";
                OleDbConnection objConn = null;
    
                try
                {
                    //create the "database" connection string 
                    connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + full + ";Extended Properties=\"HTML Import;HDR=No;IMEX=1\"";
    
                    objConn = new OleDbConnection(connString);
                    // Open connection with the database.
                    objConn.Open();
                    // Get the data table containg the schema guid.
    
                    dt = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                }
                catch
                {
                  throw exception
                }
    
                //no worksheets
                if (dt == null)
                {
                    DataCaptured = null;
                    return;
                }
    
                List<string> Sheets = new List<string>();
    
                // Add the sheet name to the string array.
    
                foreach (DataRow row in dt.Rows)
                {
                    string name = row["TABLE_NAME"].ToString();
    
                    if (string.IsNullOrEmpty(name) == false)
                    {
                        Sheets.Add(name);
                    }
                }
    
                //no worksheets
                if (excelSheets.Count == 0)
                {
                    return;
                }
    
                Dataset dataSet = new DataSet();
    
                int sheetCount = excelSheets.Count;
    
                for (int i = 0; i < sheetCount; i++)
                {
                    string sheetName = excelSheets[i];
    
                    OleDbDataAdapter ad = new OleDbDataAdapter("SELECT * FROM [" + sheetName + "]", connString);
    
                    DataTable data = new DataTable();
                    try
                    {
                        ad.Fill(data);
                    }
                    catch
                    {
                        throw exception
                    }
    
                    data.TableName = sheetName;
                    dataSet.Tables.Add(data);
    
                    adapter.Dispose();
                }
    
                objConn.Close();
    
    	    return dataSet;
