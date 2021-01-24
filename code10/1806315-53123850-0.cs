    public int GetId(string SequenceName)
    {
        int result;
    
        using (NpgsqlConnection conn = new NpgsqlConnection(connectionstring))
        {
            conn.Open();
    
            using (NpgsqlCommand id = new NpgsqlCommand(string.Format(
                "select nextval('{0}')", SequenceName), conn))
                result = Convert.ToInt32(id.ExecuteScalar());
    
            conn.Close();
        }
    
        return result;
    }
