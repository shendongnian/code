    public class ApiDbContext : IdentityDbContext<User, Role, Guid, IdentityUserClaim<Guid>, UserRole, IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
    {
            protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasMany(e => e.Role)
                .WithMany(r => r.User)
                .OnDelete(DeleteBehavior.Cascade);
    
            base.OnModelCreating(builder);
        }
    }
