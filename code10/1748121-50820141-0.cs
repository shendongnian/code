    public class User
    {
        [Key] // Becomes identity by default
        public int Id { get; set; }
        [Index("IX_User_Username", IsUnique = true)]
        public string Username { get; set; }
        public string Password { get; set; }
    }
