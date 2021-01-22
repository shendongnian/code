    public class ApplicationUser : IdentityUser
    {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public bool Active { get; set; }
            public DateTime DateRegistered { get; set; }
    }
