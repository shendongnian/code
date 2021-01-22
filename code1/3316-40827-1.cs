    private void ExecuteBatchNonQuery(string sql, SqlConnection conn) {
        string sqlBatch = string.Empty;
        SqlCommand cmd = new SqlCommand(string.Empty, conn);
        conn.Open();
        sql += "\nGO";   // make sure last batch is executed.
        try {
            foreach (string line in sql.Split(new string[2] { "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries)) {
                if (line.ToUpperInvariant().Trim() == "GO") {
                    cmd.CommandText = sqlBatch;
                    cmd.ExecuteNonQuery();
                    sqlBatch = string.Empty;
                } else {
                    sqlBatch += line + "\n";
                }
            }            
        } finally {
            conn.Close();
        }
    }
