    public DbSet<ApplicationUser> ApplicationUser { get; set; }
    public DbSet<ApplicationRole> ApplicationRole { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>()
                    .HasMany(u => u.ApplicationRoles)
                    .WithOne(r => r.ApplicationUser);
        }
