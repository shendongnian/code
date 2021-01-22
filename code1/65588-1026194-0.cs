    private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;
                        Data Source=C:\Stuff\Book1.xls;Extended Properties=
                        ""Excel 8.0;HDR=YES;""";
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                using (OleDbCommand command = conn.CreateCommand())
                {
                    command.CommandText = @"INSERT INTO [Sheet1$] (ID, Name, Site) VALUES(1, ""Phil"", ""StackOverflow.com"")";
                    conn.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
