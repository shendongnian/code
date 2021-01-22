    public string ExecuteNonQuery(string sql)
    {
        try
        {
            long i = 0;
            using (MySqlConnection conn = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.CommandText = sql;
                    i = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            return i + " row(s) affected by the last command, no resultset returned.";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }  
