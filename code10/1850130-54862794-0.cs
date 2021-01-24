     string excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={_filepath};Extended Properties='Excel 12.0;HDR=YES';";
                    // Create Connection to Excel Workbook
                    using (OleDbConnection connection = new OleDbConnection(excelConnectionString))
                    {
                        connection.Open();
                        da = new OleDbDataAdapter("Select * FROM [Sheet1$]", connection);    
                        da.Fill(dtExcelData);
                        //store data in sql server database table
                       // below connection string "conString" is I mention in app.config file.(sql server connection string to store data in sql server database)
                        string str = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
                        using (SqlConnection con = new SqlConnection(str))
                        {
                            // Bulk Copy to SQL Server
                            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(con))
                            { 
                                bulkCopy.DestinationTableName = "TableName";
                                con.Open();
                                bulkCopy.WriteToServer(dtExcelData);
                                con.Close();
                            }
                        }                        
                        connection.Close();
                    }
