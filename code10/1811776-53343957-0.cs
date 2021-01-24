    public class Game
    {
        public int Id { get; set; }
        public ICollection<GamePlayer> GamePlayers { get; set; }
    }
    public class Player
    {
        public int Id { get; set; }
        public ICollection<GamePlayer> GamePlayers { get; set; }
    }
    public class GamePlayer
    {
        public int GameId { get; set; }
        public Game Game { get; set; }
        public int PlayerId { get; set; }
        public Player Player { get; set; }
    }
    
    ...
    modelBuilder.Entity<GamePlayer>(e =>
    {
        // This safe-guards for duplicates.
        e.HasIndex(prp => new { prp.GameId, prp.PlayerId }).IsUnique();
        e.HasOne(prp => prp.Game).WithMany(prp => prp.GamePlayers).HasForeignKey(prp => prp.GameId);
        e.HasOne(prp => prp.Player).WithMany(prp => prp.GamePlayers).HasForeignKey(prp => prp.PlayerId);
    }
