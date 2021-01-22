    public class DBWrapper : IDisposable
    {
        public SqlConnection Connection1 { get; set; }
        public DBWrapper()
        {
            Connection1 = new SqlConnection();
            Connection1.Open();
        }
        public void DoWork()
        {
            // Make your DB Calls here
        }
        public void Dispose()
        {
            if (Connection1 != null)
            {
                Connection1.Dispose();
            }
        }
    }
