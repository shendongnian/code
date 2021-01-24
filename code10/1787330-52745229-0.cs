    <add name="Connectionstring"
    providerName="System.Data.SqlClient"
    connectionString="Data Source=(localdb)\ProjectsV13;Initial Catalog=TestDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False" />
----------
     class Program
    {
        private readonly string _connectionString;
        public Program()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Connectionstring"].ConnectionString;
        }
        static void Main(string[] args)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                // Do your logic here.
            }
        }
    }
