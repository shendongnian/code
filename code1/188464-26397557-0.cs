            if (fupUploadData.HasFile)
            {
                try
                {
                  ///Your connectionstrings here...
                    string path = string.Concat(Server.MapPath("~/Files/" + fupUploadData.FileName));
                    fupUploadData.SaveAs(path);
                    txtUploadData.Text = Server.MapPath(fupUploadData.FileName);
                    string excelConnectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 8.0", path);
                    OleDbConnection connection = new OleDbConnection();
                    connection.ConnectionString = excelConnectionString;
                    OleDbCommand command = new OleDbCommand("select * from [Sheet1$]", connection);
                    connection.Open();
                    DbDataReader dr = command.ExecuteReader();
                    string consString = ConfigurationManager.ConnectionStrings["mRetailerEntities"].ConnectionString;
                  
                    SqlBulkCopy bulkInsert = new SqlBulkCopy(consString);
                    bulkInsert.DestinationTableName = "offer_master";
                    bulkInsert.WriteToServer(dr);
                    lblMsg.Text = "File uploaded Successfully";
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }
          
        }
