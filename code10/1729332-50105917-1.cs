    public class AppUser : IdentityUser<Guid>
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string DisplayName => $"{ this.FirstName } { this.LastName }";
    }
    public class AppRole : IdentityRole<Guid>
    {
    }
