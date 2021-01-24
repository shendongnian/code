    public class StudentRepository : IStudentRepository
    {
        private string _connectionString;
        public DatabaseStudentRepository(string ConnectionString)
        {
            _connectionString = ConnectionString;
        }
        public object getAll()
        {
            //Load everything from my text file
        }
    }
