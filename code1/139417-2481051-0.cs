    public SqlDataReader ExecuteReaderProcedure(string ProcedureName, Hashtable Parameters)
    {
        SqlConnection conn = new SqlConnection(connectionString);
        using(SqlCommand cmd = new SqlCommand(ProcedureName, conn))
        {
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            foreach(DictionaryEntry keyValue in Parameters)
            {
                cmd.Parameters.AddWithValue(keyValue.Key.ToString(), keyValue.Value);
            }
            conn.Open();
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
    }
