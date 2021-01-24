    public class SomeContext : DbContext
    {
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Dock> Docks { get; set; }
        protected override Void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Dock>()
                .HasOne(x => x.Profile)
                .WithMany(x => x.Docks)
                .HasForeignKey(x => x.ProfileId);
        }
    }
    
    
    
    
    public class Profile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProfileId { get; set; }
        public int MatchId { get; set; }
        public virtual List<Dock> Docks { get; set; } = new List<Dock>();
    }
    public class Dock
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DockId { get; set; }
        public int MatchId { get; set; }
        
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }
    }
