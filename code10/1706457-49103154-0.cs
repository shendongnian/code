    public class MatchContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder
                .Entity<Match>()
                .HasOne<Team>(e => e.Team1)
                .WithMany(e => e.Matches)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
    public class Team
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<Match> Matches { get; set; }
    }
    public class Match
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public virtual Team Team1 { get; set; }
        [Required]
        public virtual Team Team2 { get; set; }
        public int ScoreTeam1 { get; set; }
        public int ScoreTeam2 { get; set; }
    }
