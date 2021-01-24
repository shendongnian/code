    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;
    
    namespace MyNamespaseForIdentityDatabase
    {
        public class MyDbContext : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
        {
            public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
            {
            }
    
            // DB sets for Identity entities like Users, Roles, etc. are defined in base class so you can add here your custom sets like: 
            // public virtual DbSet<Company> Companies { get; set; }
    
            protected override void OnModelCreating(ModelBuilder builder)
            {
                base.OnModelCreating(builder);
    
                ConfigureUserTable(builder);
                ConfigureRoleClaimTable(builder);
                ConfigureUserRoleTable(builder);
                ConfigureUserLoginTable(builder);
                ConfigureUserClaimTable(builder);
                ConfigureUserTokenTable(builder);
    
                // ConfigureCompaniesTable(builder);
            }
    
            private static void ConfigureUserTable(ModelBuilder builder)
            {
                builder.Entity<User>(
                    entity =>
                    {
                        entity.ToTable("Users");
                        entity.HasMany(user => user.UserRoles)
                            .WithOne(userRole => userRole.User)
                            .HasForeignKey(userRole => userRole.UserId)
                            .IsRequired()
                            .OnDelete(DeleteBehavior.Cascade);
    
                        entity.HasMany(user => user.Claims)
                            .WithOne()
                            .HasForeignKey(userClaim => userClaim.UserId)
                            .IsRequired()
                            .OnDelete(DeleteBehavior.Cascade);
    
                        entity.Property(e => e.FirstName)
                            .IsRequired();
    
                        entity.Property(e => e.LastName)
                            .IsRequired();
                    });
            }
    
            private static void ConfigureRoleClaimTable(ModelBuilder builder)
            {
                builder.Entity<RoleClaim>(
                    entity =>
                    {
                        entity.HasKey(roleClaim => roleClaim.Id);
                        entity.ToTable("RoleClaims");
                    });
            }
    
            private static void ConfigureUserRoleTable(ModelBuilder builder)
            {
                builder.Entity<UserRole>(
                    userRole =>
                    {
                        userRole.ToTable("UserRoles");
                        userRole.HasKey(
                            r => new
                            {
                                r.UserId,
                                r.RoleId
                            });
                    });
            }
    
            private static void ConfigureUserLoginTable(ModelBuilder builder)
            {
                builder.Entity<UserLogin>().ToTable("UserLogins");
            }
    
            private static void ConfigureUserClaimTable(ModelBuilder builder)
            {
                builder.Entity<UserClaim>().ToTable("UserClaims");
            }
    
            private static void ConfigureUserTokenTable(ModelBuilder builder)
            {
                builder.Entity<UserToken>().ToTable("UserTokens");
            }
        }
    
        public class User : IdentityUser<int>
        {
            // Some additional custom properties for th euser
            [NotMapped] public string FullName => $"{FirstName} {LastName}";
            public string FirstName { get; set; }
            public string LastName { get; set; }
            // Some additional collections for related stuff to include by queries like dbContext.Users.Include(user=>user.UserRoles).ToList()
            public virtual ICollection<UserRole> UserRoles { get; set; }
            public virtual ICollection<UserClaim> Claims { get; } = new List<UserClaim>();
        }
    
        public class Role : IdentityRole<int>
        {
            public Role()
            {
                // Default constructor is used by the framework
            }
    
            public Role(string roleName)
                : base(roleName)
            {
            }
    
            // Custom property in addition to Identity base ones for the role
            public string Description { get; set; }
    
            public virtual ICollection<RoleClaim> Claims { get; } = new List<RoleClaim>();
        }
    
        public class RoleClaim : IdentityRoleClaim<int>
        {
        }
    
        public class UserClaim : IdentityUserClaim<int>
        {
        }
    
        public class UserLogin : IdentityUserLogin<int>
        {
        }
    
        public class UserRole : IdentityUserRole<int>
        {
            public virtual User User { get; set; }
            public virtual Role Role { get; set; }
        }
    
        public class UserToken : IdentityUserToken<int>
        {
        }
    
        public class UserClaimsFactory : UserClaimsPrincipalFactory<User, Role>
        {
            public UserClaimsFactory(
                UserManager<User> userManager,
                RoleManager<Role> roleManager,
                IOptions<IdentityOptions> optionsAccessor)
                : base(userManager, roleManager, optionsAccessor)
            {
            }
    
            protected override async Task<ClaimsIdentity> GenerateClaimsAsync(User user)
            {
                var userId = user.Id;
                user = await UserManager.Users.SingleAsync(u => u.Id == userId);
    
                // Add role claims
                var identity = await base.GenerateClaimsAsync(user);
    
                // Add custom claims for application user properties we want to store in claims (in cookies) which allows to get common values on UI without DB hit)
                identity.AddClaim(new Claim(ClaimTypes.GivenName, user.FirstName ?? ""));
                identity.AddClaim(new Claim(ClaimTypes.Surname, user.LastName ?? ""));
                identity.AddClaim(new Claim(ClaimTypes.Email, user.Email ?? ""));
    
                return identity;
            }
        }
    }
