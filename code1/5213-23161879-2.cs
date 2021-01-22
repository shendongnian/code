    using System;
    using System.Data;
    using System.Data.OracleClient;
    
    class TestOracleInstantClient
    {
        static public void Main(string[] args)
        {
            const string host = "yourhost.yourdomain.com";
            const string serviceName = "yourservice.yourdomain.com";
            const string userId = "foo";
            const string password = "bar";
    
            var conn = new OracleConnection();
    
            // Construct a connection string using Method 1 or 2.
            conn.ConnectionString =
                GetConnectionStringMethod1(host, serviceName, userId, password);
    
            try
            {
                conn.Open();
                Console.WriteLine("Connection succeeded.");
                // Do something with the connection.
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Connection failed: " + e.Message);
            }
        }
    
        static private string GetConnectionStringMethod1(
            string host,
            string serviceName,
            string userId,
            string password
            )
        {
            string format =
                "SERVER=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)" +
                "(HOST={0})(PORT=1521))" +
                "(CONNECT_DATA=(SERVER=DEDICATED)" +
                "(SERVICE_NAME={1})));" +
                "uid={2};" +
                "pwd={3};"; // assumes port is 1521 (the default)
    
            return String.Format(format, host, serviceName, userId, password);
        }
    
        static private string GetConnectionStringMethod2(
            string host,
            string serviceName,
            string userId,
            string password
            )
        {
            string format =
                "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)" +
                "(HOST={0})(PORT=1521))" +
                "(CONNECT_DATA=(SERVER=DEDICATED)" +
                "(SERVICE_NAME={1})));" +
                "User Id={2};" +
                "Password={3};"; // assumes port is 1521 (the default)
    
            return String.Format(format, host, serviceName, userId, password);
        }
    }
