    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
        public class ApplicationUser : IdentityUser
        {
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
    
            public virtual DbSet<Cargo> Cargo { get; set; }
            public virtual DbSet<ContainerIn> ContainerIn { get; set; }
    
            public ApplicationDbContext()
                : base("DefaultConnection")
            {
            }
    
            public static ApplicationDbContext Create()
            {
                return new ApplicationDbContext();
            }
    
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {           
                modelBuilder.Entity<Cargo>()
                            .HasOptional(s => s.CompanyUserNameContainIn) 
                            .WithRequired(ad => ad.Cargo);
    
                modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
                modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
                modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
    
            }
            
        }
