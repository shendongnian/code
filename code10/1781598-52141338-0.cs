    public class User
    {
        public User(rw)
        {
           UserName = rw["UserName"].ToString();
           UserPassword = rw["UserPassword"].ToString();
           UserEmail = rw["UserEmail"].ToString();
           UserFirstName = rw["UserFirstName "].ToString();
           UserLastName = rw["UserLastName"].ToString();
        }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserEmail { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
    }
