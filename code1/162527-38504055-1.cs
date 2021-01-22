    private List<string> GetTablesInDatabase(SqlConnection connection)
    {
        using(SqlConnection conn = connection)
        {
            if(conn.State == ConnectionState.Open)
            {
                return conn.GetSchema("Tables").AsEnumerable().Select(s => s[2].ToString()).ToList();
            }
        }
        return new List<string>();        
    }
