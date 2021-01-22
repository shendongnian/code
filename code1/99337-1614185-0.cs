    public class User
    {
        private DataRow Row { get; set; };
        public User(DataRow row) { this.Row = row; }
    
        public string UserName { get { return (string)Row["Username"]; } }
        public int UserID { get { return (int)Row["UserID"]; } }
        public bool IsAdmin { get { return (bool)Row["IsAdmin"]; } }
        // ...
    }
