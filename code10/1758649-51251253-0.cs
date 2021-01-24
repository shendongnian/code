    public class User
    {
       public int Id { get; set; }
        public string Username { get; set; }
        public int? UserRoleId { get; set; }
        [ForeignKey("UserRoleId")]
        public UserRole UserRole { get; set; }
        //other user attributes
    }
