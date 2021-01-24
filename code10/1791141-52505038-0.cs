    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            
            this.UserProducts = new HashSet<UserProduct>();
            
        }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string ContactPerson { get; set; }
        [Required]
        public string ContactNumber { get; set; }
        [Required]
        public string PermanentAddress { get; set; }
        [Required]
        public string CorrespondenceAddress { get; set; }
        [Required]
        public string TIN { get; set; }
        public string PAN { get; set; }
        public string ServiceTaxNumber { get; set; }
        public string Category { get; set; }
        public virtual ICollection<UserProduct> UserProducts { get; set; }
    
        public ClaimsIdentity GenerateUserIdentity(ApplicationUserManager manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = manager.CreateIdentity(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    
        public Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager manager)
        {
            return Task.FromResult(GenerateUserIdentity(manager));
        }
    }
