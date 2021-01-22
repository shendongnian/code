        private static void VerifyFileLockedByOleDB(string fullFileName)
        {
            string file = Path.GetFileName(fullFileName);
            string dir = Path.GetDirectoryName(fullFileName);
            string cStr = "Provider=Microsoft.Jet.OLEDB.4.0;"
                + "Data Source=\"" + dir + "\\\";"
                + "Extended Properties=\"text;HDR=Yes;FMT=Delimited\";";
            string sqlStr = "SELECT * FROM [" + file + "]";
            using (OleDbConnection conn = new OleDbConnection(cStr))
            {
                OleDbCommand cmd = new OleDbCommand(sqlStr, conn);
                conn.Open();
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        File.OpenRead(fullFileName);   // should throw an exception
                        StringBuilder b = new StringBuilder();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            b.Append(reader.GetValue(i));
                            b.Append(",");
                        }
                        string line = b.ToString().Substring(0, b.Length - 1);
                        Console.WriteLine(line);
                    }
                }
            }
        }
