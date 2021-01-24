    public class Location
      {
        [Key]
        [StringLength(8)]
        public string Code { get; set; }
    
        [Required]
        [StringLength(100)]
        public string FriendlyName { get; set; }
    
        public virtual ICollection<Move> MovesTo { get; set; }
        public virtual ICollection<Move> MovesFrom { get; set; }
    
    }
    
    public class Move
    {
        [Key]
        public Guid Id { get; set; }
    
        [Required]
        public DateTime Date { get; set; }
    
        [Required]
        [StringLength(8)]
        public string LocationFromCode { get; set; }
    
        [Required]
        [StringLength(8)]
        public string LocationToCode { get; set; }
    
        [ForeignKey("LocationFromCode")]
        [InverseProperty("MovesFrom")]
        public Location LocationFrom { get; set; }
    
        [ForeignKey("LocationToCode")]
        [InverseProperty("MovesTo")]
        public Location LocationTo { get; set; }
    
    }
    
    to avoid a cyclical reference issue:
    
       protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Location>()
                    .HasMany(l => l.MovesFrom)
                    .WithRequired(m => t.LocationFrom)
                    .WillCascadeOnDelete(false);
    
                modelBuilder.Entity<Location>()
                    .HasMany(a => a.MovesTo)
                    .WithRequired(t => t.LocationTo)
                    .WillCascadeOnDelete(false);
    
            }
