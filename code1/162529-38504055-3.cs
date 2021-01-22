    public static List<string> GetTableNames(this SqlConnection connection)
    {
        using(SqlConnection conn = connection)
        {
            if(conn.State == ConnectionState.Open)
            {
                return conn.GetSchema("Tables").AsEnumerable().Select(s => s[2].ToString()).ToList();
            }            
        }
        //Add some error-handling instead !
        return new List<string>();        
    }
