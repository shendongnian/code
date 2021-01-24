    class User
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
    }
    
    // here I use 'as FirstName' to change the retrieved column name so I
    // can use "normal" C# property names on my User class
    var users = connection.Query<User>("select id, first_name as FirstName from users");
