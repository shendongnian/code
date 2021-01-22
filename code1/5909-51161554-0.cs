    public partial class PENCILS_LinqToSql_DataClassesDataContext
    {
         public PENCILS_LinqToSql_DataClassesDataContext() : base(ConnectionString(), mappingSource)
        {
        }
        public static String ConnectionString()
        {
            String CS;
            String Key;
            Key = System.Configuration.ConfigurationManager.AppSettings["DefaultConnectionString"].ToString();
            /// Get the actual connection string.
            CS = System.Configuration.ConfigurationManager.ConnectionStrings[Key].ToString();
            return CS;
        }
    }
