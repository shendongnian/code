    public class ApplicationUser : IdentityUser
    {
        public const string DisplayNameClaimType = "FirstName";
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        //etc.
    }
