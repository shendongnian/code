    private bool Import_Data_Into_SQL(string filepath, string SheetName, string Database, string Schema)
            {
                try
                {
                    // sql table should match your sheet name in excel
                    string sqltable = SheetName;
    
                    // select all data from sheet by name  
                    string exceldataquery = "select * from [" + SheetName + "$]";
    
                    //create our connection strings - Excel 2007 - This may differ based on Excel spreadsheet used
                    string excelconnectionstring = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source='" + filepath + " '; Extended Properties=Excel 8.0;";
                    string sqlconnectionstring = Properties.Settings.Default.SQL_Connection;
    
                    //series of commands to bulk copy data from the excel file into our sql table 
                    OleDbConnection oledbconn = new OleDbConnection(excelconnectionstring);
                    OleDbCommand oledbcmd = new OleDbCommand(exceldataquery, oledbconn);
                    oledbconn.Open();
                    OleDbDataReader dr = oledbcmd.ExecuteReader();
                    SqlBulkCopy bulkcopy = new SqlBulkCopy(sqlconnectionstring);
                    bulkcopy.DestinationTableName = Database + "." + Schema +"." + sqltable;
    
                    while (dr.Read())
                    {
                        bulkcopy.WriteToServer(dr);
                    }
    
                    dr.Close();
                    oledbconn.Close();
    
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
  
