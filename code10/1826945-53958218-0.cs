    public bool CheckConnection(string fname)
            {
                string extension = Path.GetExtension(fname);
                try
                {
                    string connstring = string.Empty;
                    switch (extension)
                    {
                        case ".xls":
                            connstring = string.Format(ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString, fname);
                            break;
                        case ".xlsx":
                            connstring = string.Format(ConfigurationManager.ConnectionStrings["Excel07+ConString"].ConnectionString, fname);
                            break;
                    }
                    OleDbConnection connExcel = new OleDbConnection(connstring);
                    OleDbCommand cmdExcel = new OleDbCommand();
                    cmdExcel.Connection = connExcel;
                    //bool canconnect = false;
                    try
                    {
                        
                        connExcel.Open();
                        return true;
                        //DataTable dtExcelSchema;
    
                        //dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                        // cmdExcel.ExecuteNonQuery();
                    }
                    catch 
                    {
                        return false;
                    }
                    finally
                    {
                        connExcel.Close();
                    }
                }
                catch(Exception ex)
                {
                    throw ex;
                }
                
            }
