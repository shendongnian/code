    public class ApplicationUser : IdentityUser {
    
        //Hack: Used as a workaround with DB2's data types
        public int LockoutEnabled { get; set; }
        public int EmailConfirmed { get; set; }
    }
