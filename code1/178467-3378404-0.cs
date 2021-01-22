    class User {
        public string UserName;    // no attribute
        [CsvIgnore]
        public string Password;    // will be ignored
    }
