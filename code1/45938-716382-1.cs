    public class MyConnClass : IDisposable
    {
        public static string ConnectionString { get; set; }
        protected SqlConnection conn;
        public MyConnClass()
        {
            conn = new SqlConnection(ConnectionString);
            conn.Open();
        }
        public void Dispose()
        {
            conn.Close();
        }
     }
