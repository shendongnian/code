    public static DataTable LoadDataFromDB(string query)
    {
        DataTable dt = new DataTable();
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
        {
            try
            {
                adapter.Fill(dt);
            }
            catch
            {
            }
        }
        return dt;
    }
