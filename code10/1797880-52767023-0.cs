    class Account
    {
        public int Id { get; set;}
        public string Name { get; set;}
        public int Age{ get; set;}
        public string Lastname { get; set;}
        public int Balance { get; set;}
        public string AccountType { get; set;} // this is better to be enum but your example shows you have stored string
    }
