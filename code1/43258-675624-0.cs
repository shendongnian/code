    class User {
        private string username;
    
        public string Username {
            get { return username; }
            set { username = value; }
        }
    
        public Post GetLatestPost() {
            // query the database or whatever you do here.
        }
    }
