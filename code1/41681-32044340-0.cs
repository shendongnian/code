    try
            {
                DataTable sheet1 = new DataTable("Excel Sheet");
                OleDbConnectionStringBuilder csbuilder = new OleDbConnectionStringBuilder();
                csbuilder.Provider = "Microsoft.ACE.OLEDB.12.0";
                csbuilder.DataSource = fileLocation;
                csbuilder.Add("Extended Properties", "Excel 12.0 Xml;HDR=YES");
                string selectSql = @"SELECT * FROM [Sheet1$]";
                using (OleDbConnection connection = new OleDbConnection(csbuilder.ConnectionString))
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(selectSql, connection))
                {
                    connection.Open();
                    adapter.Fill(sheet1);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
