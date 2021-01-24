    public class ApplicationUser :  IdentityUser<string>, IApplicationUser
    {
        public DateTime? LockoutEndDateUtc { get; set; }
        public bool RequiresPasswordCreation { get; set; }
        public string TemporaryToken { get; set; }
    }
