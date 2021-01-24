    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
        // Add custom user claims here => this.DepartmentId is a value stored in database against the user
        userIdentity.AddClaim(new Claim("DepartmentId", this.DepartmentId.ToString()));
            return userIdentity;
        }
    
        // Your Extended Properties
        public int? DepartmentId { get; set; }
    }
