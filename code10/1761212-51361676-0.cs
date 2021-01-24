    public class MyDal
    {
        private readonly string _connectionString;
        public MyDal(string connectionString)
        {
            _connectionString = connectionString;
        }
        public IEnumerable<string> GetSomeData()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                using (SqlCommand command = new SqlCommand(_connectionString, conn))
                {
		    ...
                }
            }
        }
    }
