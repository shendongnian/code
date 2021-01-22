    internal static class ConnectionManager 
    {
        public static SqlConnection CreateConnection()
        {
             return new SqlConnection("our connection string");
        }
    }
