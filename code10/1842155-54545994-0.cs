    public void Update_Html_Out(string key, string shortTitle, string htmlText)
    {
        string sql = @"UPDATE html_out SET 
                         short_title = :short_title, 
                         actual_text = :clob 
                       WHERE key = :key";
        using (var conn = new OracleConnection(_connectionString))
        {
            conn.Open();
            using (var transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                using (var cmd = new OracleCommand(sql, conn))
                {
                    cmd.Transaction = transaction;
                    cmd.Parameters.Add("short_title", OracleDbType.Varchar2, shortTitle, ParameterDirection.Input);
                    cmd.Parameters.Add("clob", OracleDbType.Clob, htmlText, ParameterDirection.Input);
                    cmd.Parameters.Add("key", OracleDbType.Varchar2, key, ParameterDirection.Input);
                    cmd.ExecuteNonQuery();
                }
                transaction.Commit();
            }
        }
    }
