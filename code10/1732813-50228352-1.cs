      public void dbQuery(string tablename, string[] columns, string[] values)
        {
            OleDbConnection conn2 = new OleDbConnection();
            using (OleDbCommand cmd2 = conn2.CreateCommand())
            {
                conn2.Open();
                 StringBuilder build = new StringBuilder($"INSERT INTO {tablename} {string.Join(",",columns)}");
                foreach (string paramValue in values)
                {
                    int count = 0;
                    string paramName = $"@Type0{count.ToString()}";
                    build.Append(paramName);
                     cmd2.Parameters.Add(
                     new OleDbParameter(paramName, paramValue.ToString()),
                );
                    count++;
                }
                cmd2.CommandText = "";
                cmd2.ExecuteNonQuery();
                conn2.Close();
            }
        }
