    public class DBManagerDataContext : DataContext
    {
        private static string connectionString = ""; // Your connection string
        public static DBManagerDataContext CreateInstance()
        {
            return new DBManagerDataContext(connectionString);
        }
        protected DBManagerDataContext(string connectionString)
            : base(connectionString, new AttributeMappingSource())
        {
        }
    }
