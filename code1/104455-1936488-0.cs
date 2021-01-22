    private bool IsConnectionReady(SqlConnection Connection)
    {
        bool nRet = true;
    
        try
        {
            String sql = "SELECT * FROM dummy_table";
    
            using (SqlCommand cmd = new SqlCommand(sql, Connection))
            {
                using (SqlDataReader rdr = cmd.ExecuteReader())
                { }
            }
        }
        catch (Exception ex)
        {
            nRet = false;
        }
    
        return nRet;
    }
