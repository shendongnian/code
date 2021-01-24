    public class AppUser : IdentityUser<long> {
    
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        private ICollection<AppRole> UserRoles{ get; } = new List<PostTag>();
 
        [NotMapped]
        public IEnumerable<string> RoleNames => UserRole.Role.Name
    
    }
    
    public class AppRole : IdentityRole<long> {
        private ICollection<AppRole> UserRoles{ get; } = new List<PostTag>();
 
        [NotMapped]
        public IEnumerable<AppRole> Users => UserRole.User
    }
    public class AppUserRole : IdentityUserRole<long> {
        public long UserID{ get; set; }
        public AppUser User { get; set; }
   
        public long RoleID { get; set; }
        public Role Role { get; set; }
    }
