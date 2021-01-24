    class User
    {
        public string Name { get; }
        public int RoleId { get; }
        public User(string name, int roleId)
        {
            Name = name;
            RoleId = roleId;
        }
    }
