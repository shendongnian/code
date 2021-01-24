    public class ApplicationUser : IdentityUser
    {
        public string Hometown { get; set; }
        //public virtual ICollection<Employee> Employees { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            // Disable migrations
            //Database.SetInitializer<ApplicationDbContext>(null);
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
