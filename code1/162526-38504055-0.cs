    private List<string> GetTablesInDatabase(SqlConnection connection)
    {
        if(connection.State == ConnectionState.Open)
        {
            return connection.GetSchema("Tables").AsEnumerable().Select(s => s[2].ToString()).ToList();
        }
        return new List<string>();        
    }
