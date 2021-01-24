      public class DbContext
        {
            private static MySqlConnection connection;
            private static string server;
            private static string database;
            private static string uid;
            private static string password;
    
            private static string ConnectionString = "Server=" + server + ";" + "Database=" + database + ";" + "Uid=" + uid + ";" + "Password=" + password + ";";
    
            static DbContext()
            {
                server = "testing.com";
                database = "mus_le";
                uid = "muff";
                password = "test";
            }
    
            protected object Select(string query)
            {
                using (connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
    
                    DBConnect QConnect = new DBConnect();
                    // Here I want to call this class somewhere and pass
                    // query string to it and return result from select stmt
                    MySqlCommand command = new MySqlCommand(QConnect.Initialize(), query);
                    // here I get error Unable to convert void to string...
    
                    //return result
                    return null;
                }
            }
        }
    
        public class SomeNewReader : DbContext
        {
            public object SelectSomething()
            {
                return base.Select("some query");
            }
        }
    
    
        public class SomeNewReader1 : DbContext
        {
            public object SelectSomething()
            {
                return base.Select("some query");
            }
        }
