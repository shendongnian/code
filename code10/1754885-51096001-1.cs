    class Person {
        public Person(User usr, string address)
        {
            this.User = usr;
            this.address = address;
        }
    
        public string User { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Address {
             get {
                 string toret = "N/A";
                 if ( this.User.isAdmin() ) {
                     toret = this.address;
                 }
                 
                 return toret;
             }
        }
    
        private string address;
    }
