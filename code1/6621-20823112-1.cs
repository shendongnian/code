    public string ExecuteScalar(string sql)
    {
        try
        {
            string result = "";
            using (MySqlConnection conn = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.CommandText = sql;
                    result = cmd.ExecuteScalar() + "";
                    conn.Close();
                }
            }
            return result;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    } 
