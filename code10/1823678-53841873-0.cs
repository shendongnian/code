    public class LibraryClass
    {
        private Configuration _configuration;
        public LibraryClass(Configuration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
        public void FunctionUnderTest()
        {
            string connectionString = _configuration.ConnectionStrings.ConnectionStrings["cnnName"].ConnectionString;
            // Connect to the database as you normally would.
        }
    }
