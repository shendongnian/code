    namespace MyCompany.Data.Repositories
    {
        public class User
        {
            public int Id { get; set; }
            public string Username { get; set; }
            public string Name { get; set; }
            public bool Locked { get; private set; }
        }
        public class UserRepository
        {
            public User GetAll() { }
            public User GetById() { }
            
            // Add your check password method here
        }
    }
