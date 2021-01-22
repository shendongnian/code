    namespace Data
    {
        public class DataModule
        {
            private static string _connectionString = String.Empty;
    
    
            public static string ConnectionString
            {
                get
                {
                    if (_connectionString == String.Empty)
                        throw new Exception("DataModule not initialized");
                    return _connectionString;
                }
            }
    
            public static void initialize(string connectionString)
            {
                _connectionString = connectionString;
            }
        }
    }
