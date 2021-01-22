    public class User
    {
        // [...]
        [System.ComponentModel.DataAnnotations.Association("User_Roles", "UserId", "RoleId")]
        public ICollection<Role> Roles { get; set; }
    }
    public class Role
    {
        // [...]
        [System.ComponentModel.DataAnnotations.Association("Role_Users", "RoleId", "UserId")]
        public ICollection<User> Users { get; set; }
    }
