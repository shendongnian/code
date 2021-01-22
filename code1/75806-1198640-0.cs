    private bool TableExists(string tableName)
    {
        using (SqlConnection conn = new SqlConnection(GetConnectionString()))
        {
            using (SqlCommand cmd = new SqlCommand("select count(id) from sysobjects where name = @tableName and type = 'U'", conn))
            {
                cmd.Parameters.AddWithValue("@tableName", tableName);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                conn.Close();
                return count == 1;
            }
        }
    }
