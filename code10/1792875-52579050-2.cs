    public enum Role
    {
        Admin,
        Guest
    }
    public class User
    {
        public string Name { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public Role Roles { get; set; }
    }
