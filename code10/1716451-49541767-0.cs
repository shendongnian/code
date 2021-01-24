    public class AppUser : IdentityUser<long> {
    
        public string FirstName { get; set; }
        public string LastName { get; set; }
    
        public virtual List<AppRole> Roles { get; set; }
    
    }
    
    public class AppRole : IdentityRole<long> {
        public virtual List<AppUser> Users { get; set; }
    }
