                DataTable dt = new DataTable();
                string connStr = "";
                if (fileExtension == ".xls")
                {
                    connStr = string.Format(String.Format("provider=Microsoft.Jet.OLEDB.4.0;Data Source='{0}';Extended Properties='Excel 8.0;IMEX=1;';", FullFilePath), FullFilePath, true);
                }
                else
                {
                    connStr = string.Format(String.Format("provider=Microsoft.ACE.OLEDB.12.0;Data Source='{0}';Extended Properties='Excel 12.0;IMEX=1;';", FullFilePath), FullFilePath, true);
                }
                using (OleDbConnection dbConn = new OleDbConnection(connStr))
                {
                    if (System.IO.File.Exists(FullFilePath))
                    {
                        dbConn.Open();
                        DataTable dtSchema = dbConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                        OleDbCommand dbCmd = new OleDbCommand(String.Format("SELECT * FROM [{0}]", dtSchema.Rows[0]["TABLE_NAME"]), dbConn);
                        OleDbDataAdapter dbAdp = new OleDbDataAdapter(dbCmd);
                        try
                        {
                            dbAdp.Fill(dt);
						}
					}
				}
