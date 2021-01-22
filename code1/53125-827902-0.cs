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
                Connection1.Close();
                Connection1.Dispose();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            using (DBWrapper wrapper = new DBWrapper())
            {
                wrapper.DoWork();
            }
        }
    }
