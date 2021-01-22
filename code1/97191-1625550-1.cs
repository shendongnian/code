            using (OleDbConnection conn = new OleDbConnection(cStr))
            {
                OleDbCommand cmd = new OleDbCommand(sqlStr, conn);
                conn.Open();
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        reader.GetString(0);  // breakpoint here
                    }
                }
            }
