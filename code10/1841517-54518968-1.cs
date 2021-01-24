    private static DataTable GetData(string userFileName)
        {
            string dirName = Path.GetDirectoryName(userFileName);
            string fileName = Path.GetFileName(userFileName);
            string fileExtension = Path.GetExtension(userFileName);
            string connection = string.Empty;
            string query = string.Empty;
            switch (fileExtension)
            {
                case ".xls":
                    connection = $@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={userFileName};" +
                                 "Extended Properties=\"Excel 8.0; HDR=Yes; IMEX=1\"";
                    query = "SELECT * FROM [Sheet1$]";
                    break;
                case ".xlsx":
                    connection = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={userFileName};" +
                                 "Extended Properties=\"Excel 12.0; HDR=Yes; IMEX=1\"";
                    string sheetName;
                    using (OleDbConnection con = new OleDbConnection(connection))
                    {
                        con.Open();
                        var dtSchema = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                        sheetName = dtSchema.Rows[0].Field<string>("TABLE_NAME");
                    }
                    if (sheetName.Length <= 0) throw new InvalidDataException("No sheet found."); // abort if no sheet name was returned
                    query = $"SELECT * FROM [{sheetName}]";
                    break;
                case ".csv":
                    connection = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={dirName};" +
                                 "Extended Properties=\"text; HDR=Yes; IMEX=1; FMT=Delimited\"";
                    query = $"SELECT * FROM [{fileName}]";
                    break;
            }
            return FillData(connection, query);
        }
