    public class ApplicationDbContext : IdentityDbContext<HostUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    
        public DbSet<GuestUser> GuestUsers { get; set; }
    
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
    
            builder.Entity<HostUser>(
                typeBuilder =>
                {
                    typeBuilder.HasMany(host => host.GuestUsers)
                        .WithOne(guest => guest.HostUser)
                        .HasForeignKey(guest => guest.HostUserId)
                        .IsRequired();
    
                    // ... other configuration is needed
                });
    
            builder.Entity<GuestUser>(
                typeBuilder =>
                {
                    typeBuilder.HasOne(guest => guest.HostUser)
                        .WithMany(host => host.GuestUsers)
                        .HasForeignKey(guest => guest.HostUserId)
                        .IsRequired();
    
                    // ... other configuration is needed
                });
        }
    }
