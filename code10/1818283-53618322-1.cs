    public class MyClass
    {
        private readonly IConnectionStringFactory _connectionStringFactory;
        public MyClass(IConnectionStringFactory connectionStringFactory)
        {
            _connectionStringFactory = connectionStringFactory;
        }
        public async Task<MyClass> GetDetails(int Id)
        { 
            var connectionString = _connectionStringFactory.GetConnectionString();
            con = new Connection(connectionString);
            //and after that other logic.....
        }
    }
