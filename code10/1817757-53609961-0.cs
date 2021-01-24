    public void Main()
            {
                string datetime = DateTime.Now.ToString("yyyyMMddHHmmss");
    
    
    
                //Declare Variables
    
                string FolderPath = Dts.Variables["User::FolderPath"].Value.ToString();
                string TableName = Dts.Variables["User::TableName"].Value.ToString();
                string SheetName = Dts.Variables["User::SheetName"].Value.ToString();
    
                OleDbConnection Excel_OLE_Con = new OleDbConnection();
                OleDbCommand Excel_OLE_Cmd = new OleDbCommand();
    
    
    
                //USE ADO.NET Connection for the loop initialisation
                SqlConnection myADONETConnection2 = new SqlConnection();
                myADONETConnection2 = (SqlConnection)(Dts.Connections["DBConn"].AcquireConnection(Dts.Transaction) as SqlConnection);
                //Load data into the loop table
                string queryString2 =
           "SELECT distinct PO from " + TableName;
                SqlDataAdapter adapter = new SqlDataAdapter(queryString2, myADONETConnection2);
                var table2 = new DataTable();
                adapter.Fill(table2);
                var numberofrows = table2.Rows.Count;
                for (int i = 0; i < numberofrows; i++)
                {
                    try
                    {
                        var cell = table2.Rows[i]["PO"];
    
                        string ExcelFileName = (string)cell;
                        ExcelFileName = ExcelFileName + "_" + datetime;
    
                        //Construct ConnectionString for Excel
                        string connstring = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + FolderPath + ExcelFileName
                            + ";" + "Extended Properties=\"Excel 12.0 Xml;HDR=YES;\"";
    
                        //drop Excel file if exists
                        File.Delete(FolderPath + "\\" + ExcelFileName + ".xlsx");
    
                        //USE ADO.NET Connection from SSIS Package to get data from table
    
                        SqlConnection myADONETConnection = new SqlConnection();
                        myADONETConnection = (SqlConnection)(Dts.Connections["DBConn"].AcquireConnection(Dts.Transaction) as SqlConnection);
    
    
                        //Load Data into DataTable from SQL ServerTable
                        // Assumes that connection is a valid SqlConnection object.
                        string queryString =
                          "SELECT * from " + TableName + "where PO=" + cell;
                        SqlDataAdapter adapter2 = new SqlDataAdapter(queryString, myADONETConnection);
                        DataSet ds = new DataSet();
                        adapter2.Fill(ds);
    
    
                        //Get Header Columns
                        string TableColumns = "";
    
                        // Get the Column List from Data Table so can create Excel Sheet with Header
                        foreach (DataTable table in ds.Tables)
                        {
                            foreach (DataColumn column in table.Columns)
                            {
                                TableColumns += column + "],[";
                            }
                        }
    
                        // Replace most right comma from Columnlist
                        TableColumns = ("[" + TableColumns.Replace(",", " Text,").TrimEnd(','));
                        TableColumns = TableColumns.Remove(TableColumns.Length - 2);
                        //MessageBox.Show(TableColumns);
    
    
                        //Use OLE DB Connection and Create Excel Sheet
                        Excel_OLE_Con.ConnectionString = connstring;
                        Excel_OLE_Con.Open();
                        Excel_OLE_Cmd.Connection = Excel_OLE_Con;
                        Excel_OLE_Cmd.CommandText = "Create table " + SheetName + " (" + TableColumns + ")";
                        Excel_OLE_Cmd.ExecuteNonQuery();
    
    
                        //Write Data to Excel Sheet from DataTable dynamically
                        foreach (DataTable table in ds.Tables)
                        {
                            String sqlCommandInsert = "";
                            String sqlCommandValue = "";
                            foreach (DataColumn dataColumn in table.Columns)
                            {
                                sqlCommandValue += dataColumn + "],[";
                            }
    
                            sqlCommandValue = "[" + sqlCommandValue.TrimEnd(',');
                            sqlCommandValue = sqlCommandValue.Remove(sqlCommandValue.Length - 2);
                            sqlCommandInsert = "INSERT into " + SheetName + "(" + sqlCommandValue.TrimEnd(',') + ") VALUES(";
    
                            int columnCount = table.Columns.Count;
                            foreach (DataRow row in table.Rows)
                            {
                                string columnvalues = "";
                                for (int j = 0; j < columnCount; j++)
                                {
                                    int index = table.Rows.IndexOf(row);
                                    columnvalues += "'" + table.Rows[index].ItemArray[j] + "',";
    
                                }
                                columnvalues = columnvalues.TrimEnd(',');
                                var command = sqlCommandInsert + columnvalues + ")";
                                Excel_OLE_Cmd.CommandText = command;
                                Excel_OLE_Cmd.ExecuteNonQuery();
                            }
    
                        }
                        Excel_OLE_Con.Close();
                        Dts.TaskResult = (int)ScriptResults.Success;
                        myADONETConnection.Close();
                    }
    
    
                    catch (Exception exception)
                    {
    
                        // Create Log File for Errors
                        using (StreamWriter sw = File.CreateText(Dts.Variables["User::FolderPath"].Value.ToString() + "\\" +
                            Dts.Variables["User::ExcelFileName"].Value.ToString() + ".log"))
                        {
                            sw.WriteLine(exception.ToString());
                            Dts.TaskResult = (int)ScriptResults.Failure;
    
                        }
                    }
                }
            }
            #region ScriptResults declaration
            /// <summary>
            /// This enum provides a convenient shorthand within the scope of this class for setting the
            /// result of the script.
            /// 
            /// This code was generated automatically.
            /// </summary>
            enum ScriptResults
            {
                Success = Microsoft.SqlServer.Dts.Runtime.DTSExecResult.Success,
                Failure = Microsoft.SqlServer.Dts.Runtime.DTSExecResult.Failure
            };
            #endregion
    
        }
    }
