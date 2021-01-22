    using System.Data.OleDb;
                    string physicalPath = "Your Excel file physical path";
                    OleDbCommand cmd = new OleDbCommand();
                    OleDbDataAdapter da = new OleDbDataAdapter();
                    DataSet ds = new DataSet();
                    String strNewPath = physicalPath;
                    String connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strNewPath + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                    String query = "SELECT * FROM [Sheet1$]"; // You can use any different queries to get the data from the excel sheet
                    OleDbConnection conn = new OleDbConnection(connString);
                    if (conn.State == ConnectionState.Closed) conn.Open();
                    try
                    {
                        cmd = new OleDbCommand(query, conn);
                        da = new OleDbDataAdapter(cmd);
                        da.Fill(ds);
                        
                    }
                    catch
                    {
                        // Exception Msg 
                        
                    }
                    finally
                    {
                        da.Dispose();
                        conn.Close();
                    }
