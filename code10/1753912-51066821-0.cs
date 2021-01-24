    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public int UserRoleId { get; set; } //<--- THE IMPORTANT PARTS
        public UserRole UserRole { get; set; }  //<--- THE IMPORTANT PARTS
        ...
    }
